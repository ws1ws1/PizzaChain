using PizzaChain.OrderApi.Models;

namespace PizzaChain.OrderApi.Data.Repositories
{
    public interface IOrderRepository
    {
        public Task CreateAsync(Order order);

        public Task CreateOrderDishesAsync(List<OrderDish> orderDishes);
    }
}
