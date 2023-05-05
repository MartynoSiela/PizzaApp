using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext _context;
        
        public OrderController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.PizzaSize)
                .Include(o => o.OrderToppings)
                    .ThenInclude(ot => ot.Topping)
                .ToListAsync();

            var orderDtos = orders.Select(o => new OrderDto
            (
                o.Id,
                o.PizzaSize.Name,
                o.OrderToppings.Select(ot => ot.Topping.Name).ToList(),
                o.TotalPrice
            ));

            return Ok(orderDtos);
        }

        [HttpPost("Calculate")]
        public async Task<ActionResult<decimal>> CalculatePrice(OrderInput orderRequest)
        {
            var pizzaSize = await _context.PizzaSizes.FindAsync(orderRequest.PizzaSizeId);
            if (pizzaSize == null)
            {
                return BadRequest("Invalid pizza size ID.");
            }

            var toppings = await _context.Toppings
                .Where(t => orderRequest.OrderToppings.Contains(t.Id))
                .ToListAsync();

            decimal totalPrice = pizzaSize.Price + toppings.Sum(t => t.Price);

            if (toppings.Count > 3)
            {
                totalPrice *= 0.9m;
            }

            return totalPrice;
        }

        [HttpPost("Create")]
        public IActionResult CreateOrder([FromBody] OrderInput orderInput)
        {
            try
            {
                var pizzaSize = _context.PizzaSizes.Find(orderInput.PizzaSizeId);

                if (pizzaSize == null)
                {
                    return BadRequest("Invalid pizza size ID.");
                }

                var toppings = _context.Toppings
                    .Where(t => orderInput.OrderToppings.Contains(t.Id))
                    .ToList();

                if (toppings.Count != orderInput.OrderToppings.Count)
                {
                    return BadRequest("Invalid topping ID(s).");
                }

                decimal totalPrice = pizzaSize.Price + toppings.Sum(t => t.Price);

                if (toppings.Count > 3)
                {
                    totalPrice *= 0.9m;
                }

                var orderToppings = orderInput.OrderToppings
                    .Select(toppingId => new OrderTopping { ToppingId = toppingId })
                    .ToList();

                Order order = new Order
                (
                    Guid.NewGuid(),
                    orderInput.PizzaSizeId,
                    pizzaSize,
                    orderToppings,
                    totalPrice
                );

                _context.Orders.Add(order);
                _context.SaveChanges();

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the order.");
            }
        }
    }
}
