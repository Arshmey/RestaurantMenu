using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenu.Models;

namespace RestaurantMenu.Controllers
{
    public class HomeController : Controller
    {
        private DishContext _db;

        public HomeController(DishContext db) => _db = db;

        public IActionResult Index() => View(_db.Dishes);

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpPost, AllowAnonymous]
        public ActionResult VerifyName(string name) => Json(!CheckName(name));
        
        public bool CheckName(string name)
        {
            name = name.ToLower().Trim(' ');
            return _db.Dishes.Any(x => x.Name == name);
        }
        
        public IActionResult CreateForm(Dish dish = null) => View(dish);

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateDish([Bind("Name, Composition, " +
                                             "Description, Price, Grams, Calorie, CookTime")]Dish dish)
        {
            dish.DateCreate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _db.Dishes.Add(dish);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("CreateForm", dish);
        }
    }
}