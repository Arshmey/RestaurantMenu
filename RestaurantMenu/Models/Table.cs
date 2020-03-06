using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantMenu.Models
{
    [ViewComponent(Name = "Table")]
    public class Table : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Dish> dishes)
        {
            return View(dishes);
        }
    }
}