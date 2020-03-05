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

            context.SaveChanges();
        }
    }
}