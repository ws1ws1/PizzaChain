using Microsoft.EntityFrameworkCore;
using PizzaChain.CatalogApi.Models;

namespace PizzaChain.CatalogApi.Data.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly AppDbContext _appDbContext;

        public DishRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateAsync(Dish dish)
        {
            _appDbContext.Dishes.Add(dish);
            var t = await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dish>> GetAllAsync()
        {
            var dishes = await _appDbContext.Dishes.ToListAsync();
            return dishes;
        }
    }
}
