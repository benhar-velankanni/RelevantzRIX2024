using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NameService.Data;
using NameService.Model;

namespace NameService.Controllers
{ 
    
    [ApiController]
    [Route("api/[controller]")]
    public class NameServiceController : ControllerBase
    {
        private readonly AppDbContext _Context;

        public NameServiceController(AppDbContext context)
        {
            _Context = context;
        }

        //Get: api/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var names = await _Context.Names.ToListAsync();
            return Ok(names);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var name = await _Context.Names.FindAsync(id);
            if (name == null) return NotFound();
            else return Ok(name);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Name nameItem)
        {
            _Context.Names.Add(nameItem);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), nameItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Name nameItem)
        {
            var name = await _Context.Names.FindAsync(id);
            if (name == null) return NotFound();
            name.UserName = nameItem.UserName;
            await _Context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var name = await _Context.Names.FindAsync(id);
            if (name == null) return NotFound();
            _Context.Names.Remove(name);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
    }
}

