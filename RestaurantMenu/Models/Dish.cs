using System;

namespace RestaurantMenu.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Weight { get; set; }
        public int CookTime { get; set; }
    }
}