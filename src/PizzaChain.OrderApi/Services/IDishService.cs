using PizzaChain.OrderApi.DTOs;

namespace PizzaChain.OrderApi.Services
{
    public interface IDishService
    {
        public Task<List<DishDto>> GetAllDishesAsync();
    }
}
