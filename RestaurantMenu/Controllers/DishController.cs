using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenu.Models;

namespace RestaurantMenu.Controllers
{
    public class DishController : Controller
    {
        private DishContext _db;

        public DishController(DishContext db) => _db = db;
        
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
            if (!ModelState.IsValid) return RedirectToAction("CreateForm", dish);
            
            dish.DateCreate = DateTime.Now;
            _db.Dishes.Add(dish);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}