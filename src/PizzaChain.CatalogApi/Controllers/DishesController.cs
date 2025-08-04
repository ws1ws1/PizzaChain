using Microsoft.AspNetCore.Mvc;
using PizzaChain.CatalogApi.Data.Repositories;
using PizzaChain.CatalogApi.Models;

namespace PizzaChain.CatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishRepository _repository;

        public DishesController(IDishRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(string nameDish)
        {
            await _repository.CreateAsync(new Dish { Name = nameDish });
            return Ok();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var dishes = await _repository.GetAllAsync();

            return Ok(dishes);
        }
    }
}
