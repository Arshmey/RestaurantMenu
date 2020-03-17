using Microsoft.AspNetCore.Mvc;

namespace RestaurantMenu.Models
{
    [ViewComponent(Name = "Table")]
    public class Table : ViewComponent
    {
        public IViewComponentResult Invoke(TableViewModel dishes) => View(dishes);
    }
}