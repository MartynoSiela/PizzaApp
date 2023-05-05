namespace PizzaApp.Models
{
    public class OrderInput
    {
        public Guid PizzaSizeId { get; set; }
        public List<Guid> OrderToppings { get; set; }
    }
}
