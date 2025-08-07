namespace PizzaChain.OrderApi.DTOs
{
    public class CreatedOrder
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public List<int> DishIds { get; set; } = new();
    }
}
