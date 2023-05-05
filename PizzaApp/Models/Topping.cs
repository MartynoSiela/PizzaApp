namespace PizzaApp.Models
{
    public class Topping
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Pepperoni, Mushrooms, Onions, etc.
        public decimal Price { get; set; }
        public ICollection<OrderTopping> OrderToppings { get; set; }

        public Topping(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
