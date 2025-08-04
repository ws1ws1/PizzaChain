using PizzaChain.CatalogApi.Models;

namespace PizzaChain.CatalogApi.Data.Repositories
{
    public interface IDishRepository
    {
        public Task CreateAsync(Dish dish);

        public Task<IEnumerable<Dish>> GetAllAsync();
    }
}
