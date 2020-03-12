using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RestaurantMenu.Models
{
    public class DishContextFactory : IDesignTimeDbContextFactory<DishContext>
    {
        public DishContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../RestaurantMenu/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<DishContext>();
            var connectionString = configuration.GetConnectionString("Db");
            builder.UseSqlServer(connectionString);

            return new DishContext(builder.Options);
        }
    }
}