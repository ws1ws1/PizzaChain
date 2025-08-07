using Microsoft.EntityFrameworkCore;
using PizzaChain.OrderApi.Models;

namespace PizzaChain.OrderApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDish> OrderDishes { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDish>()
                .HasKey(x => new { x.OrderId, x.DishId});

            modelBuilder.Entity<OrderDish>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDishes)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
