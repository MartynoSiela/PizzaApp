using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaSizeController : ControllerBase
    {
        private readonly DatabaseContext _context;
        
        public PizzaSizeController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PizzaSize> Get()
        {
            return _context.PizzaSizes.ToArray();
        }
    }
}
