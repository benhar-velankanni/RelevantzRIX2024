using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSalonManagementSystem.Models;

namespace OnlineSalonManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerApiController : ControllerBase
    {
        private readonly OnlineSalonManagementDbContext _context;

        public CustomerApiController(OnlineSalonManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerApi
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        // GET: api/CustomerApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/CustomerApi
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return Ok(customer);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/CustomerApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        // DELETE: api/CustomerApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }
    }
}

