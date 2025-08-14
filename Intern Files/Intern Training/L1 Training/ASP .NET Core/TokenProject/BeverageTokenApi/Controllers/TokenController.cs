using BeverageTokenApi.Services;
using BeverageTokenApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BeverageTokenApi.Controllers;

[Authorize(Roles = "User")]
[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly AppDbContext _context;

    public TokenController(TokenService tokenService, AppDbContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost("request")]
    public async Task<IActionResult> RequestToken([FromQuery] string beverage)
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) return Unauthorized();

        var result = await _tokenService.RequestToken(user.Id, beverage);
        return Ok(result);
    }
    [HttpGet("history")]
public async Task<IActionResult> GetUserHistory()
{
    var email = User.FindFirst(ClaimTypes.Email)?.Value;
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    if (user == null) return Unauthorized();

    var tokens = await _context.TokenRequests
        .Where(tr => tr.UserId == user.Id)
        .OrderByDescending(tr => tr.RequestTime)
        .Select(tr => new
        {
            tr.BeverageType,
            tr.RequestTime,
            tr.IsClaimed
        }).ToListAsync();

    return Ok(tokens);
}


}
