using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantMenu.Models;

namespace RestaurantMenu.Controllers
{
    public class DishController : Controller
    {
        private DishContext db;
        private ILogger<DishController> logger;

        public DishController(DishContext db, ILogger<DishController> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        [HttpPost, AllowAnonymous]
        public ActionResult VerifyName(string name) => Json(!CheckName(name));

        public bool CheckName(string name)
        {
            name = name.ToLower().Trim(' ');
            return db.Dishes.Any(x => x.Name == name);
        }

        public IActionResult Create(Dish dish = null) => View(dish);

        public IActionResult Edit(int? id)
        {
            Dish dish = db.Dishes.FirstOrDefault(p => p.Id == id);
            if (id != null)
            {
                if (dish != null)
                    return View(dish);
            }

            return NotFound();
        }

        public IActionResult Delete(int? id)
        {
            logger.LogInformation($"ID : {id}");
            Dish dish = db.Dishes.FirstOrDefault(p => p.Id == id);
            if (id != null)
            {
                logger.LogInformation("Found");
                if (dish != null)
                    return View(dish);
            }

            logger.LogError("Not Found");
            return NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateDish([Bind("Name, Composition, " +
                                             "Description, Price, Grams, Calorie, CookTime")]
            Dish model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Create", model);

            model.DateCreate = DateTime.Now;
            db.Dishes.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Edit(Dish model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Edit", model);

            db.Dishes.Update(model);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ReturnHome()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Delete(Dish model)
        {
            logger.LogInformation($"Deleted {model}");
            if (model != null)
            {
                db.Dishes.Remove(model);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}