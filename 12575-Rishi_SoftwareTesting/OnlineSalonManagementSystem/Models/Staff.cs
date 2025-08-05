using System.ComponentModel.DataAnnotations;

namespace OnlineSalonManagementSystem.Models;

public partial class Staff
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [StringLength(255, ErrorMessage = "Email cannot be longer than 255 characters")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone is required")]
    [StringLength(20, ErrorMessage = "Phone cannot be longer than 20 characters")]
    [Phone(ErrorMessage = "Invalid phone number")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Role is required")]
    [StringLength(255, ErrorMessage = "Role cannot be longer than 255 characters")]
    public string Role { get; set; } = null!;

    public int SalonId { get; set; }

    public virtual ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();

    public virtual Salon? Salon { get; set; } = null!;
}

