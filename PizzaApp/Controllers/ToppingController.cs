using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToppingController : ControllerBase
    {
        private readonly DatabaseContext _context;
        
        public ToppingController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Topping> Get()
        {
            return _context.Toppings.ToArray();
        }
    }
}
