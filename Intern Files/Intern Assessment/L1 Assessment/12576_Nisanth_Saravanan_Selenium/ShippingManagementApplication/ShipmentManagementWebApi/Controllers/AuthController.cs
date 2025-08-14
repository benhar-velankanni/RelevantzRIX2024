using Microsoft.AspNetCore.Mvc;
using ShipmentManagementWebApi.Services;
using ShipmentManagementWebApi.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        user.Role = "User"; // Default role
        if (_authService.Register(user)) return Ok("Registered successfully");
        return BadRequest("Username already exists");
    }

    [HttpPost("login")]
    public IActionResult Login(User user)
    {
        var loggedInUser = _authService.Authenticate(user.Username, user.Password);
        if (loggedInUser == null) return Unauthorized("Invalid credentials");
        return Ok(loggedInUser); // Return user object with role
    }
}
