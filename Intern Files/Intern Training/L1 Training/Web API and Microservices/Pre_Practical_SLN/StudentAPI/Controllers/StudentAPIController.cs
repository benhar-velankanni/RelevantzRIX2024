//Controller.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Model;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly AppDbContext _Context;

        public StudentAPIController(AppDbContext context)
        {
            _Context = context;
        }

        //Get: api/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _Context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var students = await _Context.Students.FindAsync(id);
            if (students == null) return NotFound();
            else return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student studentItem)
        {
            _Context.Students.Add(studentItem);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), studentItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Student studentItem)
        {
            var student = await _Context.Students.FindAsync(id);
            if (student == null) return NotFound();
            student.Name = studentItem.Name;
            student.ClassAndSection = studentItem.ClassAndSection;
            student.DateOfBirth = studentItem.DateOfBirth;
            await _Context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _Context.Students.FindAsync(id);
            if (student == null) return NotFound();
            _Context.Students.Remove(student);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
    }
}
