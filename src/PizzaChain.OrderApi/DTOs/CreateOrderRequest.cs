namespace PizzaChain.OrderApi.DTOs
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; }

        public List<int> DishIds { get; set; }
    }
}
