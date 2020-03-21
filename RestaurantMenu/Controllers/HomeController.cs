using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenu.Models;

namespace RestaurantMenu.Controllers
{
    public class HomeController : Controller
    {
        public const int ElementsInPage = 20;

        private DishContext _db;

        public HomeController(DishContext db) => _db = db;

        public IActionResult Index(int pageNumber = 1, DishSortState sortOrder = DishSortState.DateCreateAsc)
        {
            IQueryable<Dish> dishes = _db.Dishes.Skip((pageNumber - 1) * ElementsInPage).Take(ElementsInPage);
            
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentPage"] = pageNumber;
            sortOrder.CurrentSortStates().ForEach(x => ViewData.Add(x));

            dishes = dishes.SortDishes(sortOrder);
            PageInfo pageInfo = new PageInfo{PageNumber = pageNumber, PageSize = ElementsInPage, TotalItems = _db.Dishes.Count()};
            TableViewModel tvm = new TableViewModel{PageInfo = pageInfo, Dishes = dishes};
            
            return View(tvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}