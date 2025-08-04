using Microsoft.EntityFrameworkCore;
using PizzaChain.CatalogApi.Models;

namespace PizzaChain.CatalogApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
