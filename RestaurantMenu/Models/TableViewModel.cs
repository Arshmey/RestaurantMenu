using System;
using System.Collections.Generic;

namespace RestaurantMenu.Models
{
    public class TableViewModel
    {
        public IEnumerable<Dish> Dishes { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / PageSize);
    }
}