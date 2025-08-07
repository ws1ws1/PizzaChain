using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaChain.OrderApi.Models
{
    public class OrderDish
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int DishId { get; set; }
    }
}
