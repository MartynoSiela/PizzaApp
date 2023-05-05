namespace PizzaApp.Models
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string PizzaSizeName { get; set; }
        public List<string> Toppings { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderDto(Guid id, string pizzaSizeName, List<string> toppings, decimal totalPrice)
        {
            Id = id;
            PizzaSizeName = pizzaSizeName;
            Toppings = toppings;
            TotalPrice = totalPrice;
        }
    }
}
