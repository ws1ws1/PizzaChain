using PizzaChain.OrderApi.DTOs;

namespace PizzaChain.OrderApi.Services
{
    public class DishService : IDishService
    {
        private readonly HttpClient _httpClient;

        public DishService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7107/");
        }

        public async Task<List<DishDto>> GetAllDishesAsync()
        {
            var dishes = await _httpClient.GetFromJsonAsync<List<DishDto>>("api/dishes/getall");

            return dishes;
        }
    }
}
