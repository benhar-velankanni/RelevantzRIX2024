//Controller.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherAPI.Data;
using TeacherAPI.Model;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly AppDbContext _Context;

        public TeacherAPIController(AppDbContext context)
        {
            _Context = context;
        }

        //Get: api/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _Context.Teachers.ToListAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var teachers = await _Context.Teachers.FindAsync(id);
            if (teachers == null) return NotFound();
            else return Ok(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Teacher teacherItem)
        {
            _Context.Teachers.Add(teacherItem);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), teacherItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Teacher teacherItem)
        {
            var teacher = await _Context.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            teacher.Name = teacherItem.Name;
            teacher.Subject = teacherItem.Subject;
            teacher.DateOfJoining = teacherItem.DateOfJoining;
            await _Context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _Context.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            _Context.Teachers.Remove(teacher);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
    }
}
