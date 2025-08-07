using PizzaChain.OrderApi.DTOs;

namespace PizzaChain.OrderApi.Services
{
    public interface IOrderService
    {
        public Task<CreatedOrder> CreateAsync(CreateOrderRequest createOrderRequest);
    }
}
