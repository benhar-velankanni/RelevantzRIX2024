//Controller.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanguageDetectionService.Data;
using LanguageDetectionService.Model;

namespace LanguageDetectionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageDetectionController : ControllerBase
    {
        private readonly AppDbContext _Context;

        public LanguageDetectionController(AppDbContext context)
        {
            _Context = context;
        }

        //Get: api/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var languageItems = await _Context.LanguageDetections.ToListAsync();
            return Ok(languageItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var languageItem = await _Context.LanguageDetections.FindAsync(id);
            if (languageItem == null) return NotFound();
            else return Ok(languageItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LanguageDetection languageItem)
        {
            _Context.LanguageDetections.Add(languageItem);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), languageItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LanguageDetection languageItem)
        {
            var languageItemToUpdate = await _Context.LanguageDetections.FindAsync(id);
            if (languageItemToUpdate == null) return NotFound();
            languageItemToUpdate.Name = languageItem.Name;
            languageItemToUpdate.Origin = languageItem.Origin;
            languageItemToUpdate.Notes = languageItem.Notes;
            await _Context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _Context.LanguageDetections.FindAsync(id);
            if (student == null) return NotFound();
            _Context.LanguageDetections.Remove(student);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
    }
}
