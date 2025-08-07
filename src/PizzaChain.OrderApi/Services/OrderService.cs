using PizzaChain.OrderApi.Data.Repositories;
using PizzaChain.OrderApi.DTOs;
using PizzaChain.OrderApi.Models;

namespace PizzaChain.OrderApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IDishService _dishService;

        public OrderService (IOrderRepository orderRepository, IDishService dishService)
        {
            _orderRepository = orderRepository;
            _dishService = dishService;
        }

        public async Task<CreatedOrder> CreateAsync(CreateOrderRequest createOrderRequest)
        {
            // нужно ли использовать транзакцию?
            try
            {
                var dishes = await _dishService.GetAllDishesAsync();

                //проверка наличия блюд
                if (createOrderRequest.DishIds.Count != dishes.Count)
                {
                    var missingDishes = createOrderRequest.DishIds.Except(dishes.Select(d => d.Id));
                    throw new ArgumentException($"Dishes not found: {string.Join(",", missingDishes)}");
                }

                var order = new Order
                {
                    CustomerName = createOrderRequest.CustomerName
                };

                await _orderRepository.CreateAsync(order);

                var orderDishes = new List<OrderDish>();
                foreach (var dishId in createOrderRequest.DishIds)
                {
                    var orderDish = new OrderDish
                    {
                        OrderId = order.Id,
                        DishId = dishId
                    };

                    orderDishes.Add(orderDish);
                }

                await _orderRepository.CreateOrderDishesAsync(orderDishes);

                return new CreatedOrder
                {
                    Id = order.Id,
                    CustomerName = order.CustomerName,
                    DishIds = orderDishes.Select(d => d.DishId).ToList()
                };
            }
            catch (Exception ex)
            {
                // вопрос по работе с исключениями, как организуется? лучшие решения? 
                throw;
            }
        }
    }
}
