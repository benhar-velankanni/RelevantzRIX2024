using System.ComponentModel.DataAnnotations;

namespace OnlineSalonManagementSystem.Models;

public partial class Customer
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [StringLength(255, ErrorMessage = "Email cannot be longer than 255 characters")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone is required")]
    [StringLength(20, ErrorMessage = "Phone cannot be longer than 20 characters")]
    public string Phone { get; set; } = null!;

    public virtual ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();
}

