namespace PizzaApp.Models
{
    public class PizzaSize
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Small, Medium, or Large
        public decimal Price { get; set; } // 8, 10, or 12 (in euros)

        public PizzaSize(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
