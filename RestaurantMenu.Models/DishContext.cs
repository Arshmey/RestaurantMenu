using Microsoft.EntityFrameworkCore;

namespace RestaurantMenu.Models
{
    public class DishContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        
        public DishContext(DbContextOptions<DishContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().ToTable("Dish");
        }
    }
}