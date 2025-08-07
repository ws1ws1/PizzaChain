using PizzaChain.OrderApi.Models;

namespace PizzaChain.OrderApi.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateAsync(Order order)
        {
            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();
        }

        // другой репозиторий надо создать?
        public async Task CreateOrderDishesAsync(List<OrderDish> orderDishes)
        {
            _appDbContext.OrderDishes.AddRange(orderDishes);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
