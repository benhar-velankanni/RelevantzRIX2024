using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSalonManagementSystem.Models;

namespace OnlineSalonManagementSystem.Controllers
{
    public class AdminLogController : Controller
    {
        private readonly OnlineSalonManagementDbContext _context;

        public AdminLogController(OnlineSalonManagementDbContext context)
        {
            _context = context;
        }

        // GET: AdminLog/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: AdminLog/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Name,Email,Password")] AdminLog adminLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminLog);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "User created successfully";
                return RedirectToAction(nameof(Login));
            }
            TempData["ErrorMessage"] = "Something went wrong";
            return View(adminLog);
        }

        // GET: AdminLog/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: AdminLog/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] AdminLog adminLog)
        {
            var foundUser = await _context.AdminLogs
                .FirstOrDefaultAsync(u => u.Email == adminLog.Email && u.Password == adminLog.Password);

            if (foundUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, foundUser.Name)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                TempData["SuccessMessage"] = "Login successful";
                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorMessage"] = "Invalid username or password";
            return View(adminLog);
        }

        // POST: AdminLog/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["InfoMessage"] = "Logged out successfully";
            return RedirectToAction("Login", "AdminLog");
        }

        // GET: AdminLog
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminLogs.ToListAsync());
        }
    }
}

