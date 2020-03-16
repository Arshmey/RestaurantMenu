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

        public IActionResult Create(Dish dish = null) => View(dish);

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Dish dish = _db.Dishes.FirstOrDefault(p => p.Id == id);
                if (dish != null)
                    return View(dish);
            }

            return NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateDish([Bind("Name, Composition, " +
                                             "Description, Price, Grams, Calorie, CookTime")]
            Dish model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Create", model);

            model.DateCreate = DateTime.Now;
            _db.Dishes.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Edit(Dish model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Edit", model);

            _db.Dishes.Update(model);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Delete(Dish model)
        {
            Dish dish = _db.Dishes.Find(model);
            if (dish != null)
            {
                _db.Dishes.Remove(dish);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}