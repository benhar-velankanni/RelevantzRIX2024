//Controller.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranslationEngineService.Data;
using TranslationEngineService.Model;

namespace TranslationEngineService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationEngineController : ControllerBase
    {
        private readonly AppDbContext _Context;

        public TranslationEngineController(AppDbContext context)
        {
            _Context = context;
        }

        //Get: api/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _Context.TranslationEngines.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var translationItem = await _Context.TranslationEngines.FindAsync(id);
            if (translationItem == null) return NotFound();
            else return Ok(translationItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TranslationEngine translationItem)
        {
            _Context.TranslationEngines.Add(translationItem);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), translationItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TranslationEngine translationItem)
        {
            var translationItemToUpdate = await _Context.TranslationEngines.FindAsync(id);
            if (translationItemToUpdate == null) return NotFound();
            translationItemToUpdate.TranslationString = translationItem.TranslationString;
            await _Context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _Context.TranslationEngines.FindAsync(id);
            if (student == null) return NotFound();
            _Context.TranslationEngines.Remove(student);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
    }
}
