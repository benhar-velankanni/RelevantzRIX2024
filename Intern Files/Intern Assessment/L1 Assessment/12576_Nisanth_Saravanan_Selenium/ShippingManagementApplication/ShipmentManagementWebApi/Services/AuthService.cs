using ShipmentManagementWebApi.Data;
using ShipmentManagementWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ShipmentManagementWebApi.Services;

public class AuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public User Authenticate(string username, string password)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    public bool Register(User user)
    {
        if (_context.Users.Any(u => u.Username == user.Username)) return false;
        _context.Users.Add(user);
        _context.SaveChanges();
        return true;
    }
}

