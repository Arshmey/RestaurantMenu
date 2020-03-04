using Microsoft.EntityFrameworkCore.Internal;
using RestaurantMenu.Models;

namespace RestaurantMenu.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DishContext context)
        {
            context.Database.EnsureCreated();

            if (context.Dishes.Any())
            {
                return;
            }
            
            var dishes = new []
            {
                new Dish{Name = "Плов", Composition = "Рис, Мясо", Description = "Просто плов", Price = 100, Grams = 300, Calorie = 150, CookTime = 30}, 
            };
            foreach (var dish in dishes)
            {
                context.Dishes.Add(dish);
            }

            context.SaveChanges();
        }
    }
}