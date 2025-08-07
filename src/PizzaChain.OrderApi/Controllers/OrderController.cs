using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaChain.OrderApi.Data.Repositories;
using PizzaChain.OrderApi.DTOs;
using PizzaChain.OrderApi.Models;
using PizzaChain.OrderApi.Services;

namespace PizzaChain.OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IDishService _dishService;

        private readonly IOrderService _orderService;

        public OrderController(IDishService dishService, IOrderService orderService)
        {
            _dishService = dishService;
            _orderService = orderService;
        }

        [HttpGet("getalldishes")]
        public async Task<IActionResult> GetAllDishes()
        {
            var dishes = await _dishService.GetAllDishesAsync();

            return Ok(dishes);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateOrderRequest createOrderRequest)
        {
            // в try catch надо заваричивать? и делать мидлваре обработки ошибок?
            var order = await _orderService.CreateAsync(createOrderRequest);

            return Ok(order);
        }
    }
}
