namespace PizzaApp.Models
{
    public class OrderTopping
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}
