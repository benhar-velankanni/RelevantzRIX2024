using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssessmentPratice.Data;
using AssessmentPratice.Models;

namespace AssessmentPratice.Controllers
{
    public class EnrollController : Controller
    {
        private readonly AppDbContext _context;

        public EnrollController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Enroll
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Enrolls.Include(e => e.Course).Include(e => e.Student);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Enroll/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enrolls
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrollId == id);
            if (enroll == null)
            {
                return NotFound();
            }

            return View(enroll);
        }

        // GET: Enroll/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: Enroll/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollId,StudentId,CourseId")] Enroll enroll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enroll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enroll.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", enroll.StudentId);
            return View(enroll);
        }

        // GET: Enroll/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enrolls.FindAsync(id);
            if (enroll == null)
            {
                return NotFound();
            }
            ViewBag.StudentName = new SelectList(_context.Students, "StudentId", "StudentName");
            ViewBag.CourseName = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enroll.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", enroll.StudentId);
            return View(enroll);
        }

        // POST: Enroll/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollId,StudentId,CourseId")] Enroll enroll)
        {
            if (id != enroll.EnrollId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enroll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollExists(enroll.EnrollId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enroll.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", enroll.StudentId);
            return View(enroll);
        }

        // GET: Enroll/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enrolls
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrollId == id);
            if (enroll == null)
            {
                return NotFound();
            }

            return View(enroll);
        }

        // POST: Enroll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enroll = await _context.Enrolls.FindAsync(id);
            if (enroll != null)
            {
                _context.Enrolls.Remove(enroll);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollExists(int id)
        {
            return _context.Enrolls.Any(e => e.EnrollId == id);
        }
    }
}
