using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineSalonManagementSystem.Models;

namespace OnlineSalonManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        private readonly OnlineSalonManagementDbContext _context;

        public StaffController(OnlineSalonManagementDbContext context)
        {
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            var onlineSalonManagementDbContext = _context.Staffs.Include(s => s.Salon);
            return View(await onlineSalonManagementDbContext.ToListAsync());
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .Include(s => s.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id");
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,Role,SalonId")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Staff added successfully";
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", staff.SalonId);
            TempData["ErrorMessage"] = "Error adding staff";
            return View(staff);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", staff.SalonId);
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,Role,SalonId")] Staff staff)
        {
            if (id != staff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Staff updated successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.Id))
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
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", staff.SalonId);
            TempData["ErrorMessage"] = "Error updating staff";
            return View(staff);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .Include(s => s.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Staff deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.Id == id);
        }
    }
}

