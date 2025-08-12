using System.ComponentModel.DataAnnotations;

namespace OnlineSalonManagementSystem.Models;

public partial class AdminLog
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(255, ErrorMessage = "Email cannot be longer than 255 characters")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, ErrorMessage = "Password cannot be longer than 255 characters")]
    public string Password { get; set; } = null!;
}

