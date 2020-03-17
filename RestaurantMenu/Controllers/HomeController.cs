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
            ViewData["DateCreateSort"] = sortOrder == DishSortState.DateCreateAsc
                ? DishSortState.DateCreateDesc
                : DishSortState.DateCreateAsc;
            ViewData["NameSort"] = sortOrder == DishSortState.NameAsc
                ? DishSortState.NameDesc
                : DishSortState.NameAsc;
            ViewData["CompositionSort"] = sortOrder == DishSortState.CompositionAsc
                ? DishSortState.CompositionDesc
                : DishSortState.CompositionAsc;
            ViewData["DescriptionSort"] = sortOrder == DishSortState.DescriptionAsc
                ? DishSortState.DescriptionDesc
                : DishSortState.DescriptionAsc;
            ViewData["PriceSort"] = sortOrder == DishSortState.PriceAsc
                ? DishSortState.PriceDesc
                : DishSortState.PriceAsc;
            ViewData["GramsSort"] = sortOrder == DishSortState.GramsAsc
                ? DishSortState.GramsDesc
                : DishSortState.GramsAsc;
            ViewData["CalorieSort"] = sortOrder == DishSortState.CalorieAsc
                ? DishSortState.CalorieDesc
                : DishSortState.CalorieAsc;
            ViewData["CookTimeSort"] = sortOrder == DishSortState.CookTimeAsc
                ? DishSortState.CookTimeDesc
                : DishSortState.CookTimeAsc;

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