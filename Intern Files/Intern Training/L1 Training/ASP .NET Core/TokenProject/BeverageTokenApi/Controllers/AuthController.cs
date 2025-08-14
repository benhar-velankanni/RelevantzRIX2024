using BeverageTokenApi.DTOs;
using BeverageTokenApi.Helpers;
using BeverageTokenApi.Models;
using BeverageTokenApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BeverageTokenApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var exists = await _context.Users.AnyAsync(u => u.Email == request.Email);
        if (exists) return BadRequest("User already exists.");

        var hash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(request.Password)));

        var user = new User
        {
            Email = request.Email,
            PasswordHash = hash,
            Role = "User"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
public async Task<IActionResult> Login(LoginRequest request)
{
    var hash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(request.Password)));

    var user = await _context.Users.FirstOrDefaultAsync(u =>
        u.Email == request.Email && u.PasswordHash == hash);

    if (user == null) return Unauthorized("Invalid credentials.");

    var token = JwtHelper.GenerateToken(user.Email, user.Role, _config);

    return Ok(new
    {
        token,
        role = user.Role,
        email = user.Email
    });
}

}
