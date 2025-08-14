//Controller.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlossaryManagementService.Data;
using GlossaryManagementService.Model;

namespace GlossaryManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlossaryManagementController : ControllerBase
    {
        private readonly AppDbContext _Context;

        public GlossaryManagementController(AppDbContext context)
        {
            _Context = context;
        }

        //Get: api/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var glosssaryItems = await _Context.GlossaryManagements.ToListAsync();
            return Ok(glosssaryItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var glosssaryItem = await _Context.GlossaryManagements.FindAsync(id);
            if (glosssaryItem == null) return NotFound();
            else return Ok(glosssaryItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GlossaryManagement glosssaryItem)
        {
            _Context.GlossaryManagements.Add(glosssaryItem);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), glosssaryItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GlossaryManagement glosssaryItem)
        {
            var glosssaryItemToUpdate = await _Context.GlossaryManagements.FindAsync(id);
            if (glosssaryItemToUpdate == null) return NotFound();
            glosssaryItemToUpdate.Word = glosssaryItem.Word;
            glosssaryItemToUpdate.Meaning = glosssaryItem.Meaning;
            glosssaryItemToUpdate.Notes = glosssaryItem.Notes;
            await _Context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var glosssaryItem = await _Context.GlossaryManagements.FindAsync(id);
            if (glosssaryItem == null) return NotFound();
            _Context.GlossaryManagements.Remove(glosssaryItem);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
    }
}
