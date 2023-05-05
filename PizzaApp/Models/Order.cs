namespace PizzaApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid PizzaSizeId { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public ICollection<OrderTopping> OrderToppings { get; set; }
        public decimal TotalPrice { get; set; }

        public Order()
        {

        }

        public Order(Guid id, Guid pizzaSizeId, PizzaSize pizzaSize, ICollection<OrderTopping> orderToppings, decimal totalPrice)
        {
            Id = id;
            PizzaSizeId = pizzaSizeId;
            PizzaSize = pizzaSize;
            OrderToppings = orderToppings;
            TotalPrice = totalPrice;
        }
    }
}
