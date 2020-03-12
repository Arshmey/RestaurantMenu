using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantMenu.Models
{
    [ViewComponent(Name = "Table")]
    public class Table : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Dish> dishes) => View(dishes);

        public static string CountTime(Dish dish)
        {
            int hours = TimeSpan.FromMinutes(dish.CookTime).Hours;
            int ostMin = dish.CookTime - hours* 60;
            switch (hours)
            {
                case 1:
                    return $"{hours} час {ostMin} мин.";
                case 2:
                case 3:
                case 4:
                    return $"{hours} часа {ostMin} мин.";
                default:
                    return hours >= 5 ? $"{hours} часов {ostMin} мин." : $"{dish.CookTime} мин.";
            }
        }

        public static string CountCalorie(Dish dish)
        {
            decimal finalCalorie = dish.Grams * (dish.Calorie / 100);
            return $"{finalCalorie} ккал.";
        }
    }
}