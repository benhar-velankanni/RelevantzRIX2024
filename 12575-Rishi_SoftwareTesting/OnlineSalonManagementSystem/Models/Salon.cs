using System.ComponentModel.DataAnnotations;

namespace OnlineSalonManagementSystem.Models;

public partial class Salon
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Address is required")]
    [StringLength(255, ErrorMessage = "Address cannot be longer than 255 characters")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "Phone is required")]
    [StringLength(20, ErrorMessage = "Phone cannot be longer than 20 characters")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [StringLength(255, ErrorMessage = "Email cannot be longer than 255 characters")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Website is required")]
    [StringLength(255, ErrorMessage = "Website cannot be longer than 255 characters")]
    public string Website { get; set; } = null!;

    public virtual ICollection<Inventory>? Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Service>? Services { get; set; } = new List<Service>();

    public virtual ICollection<Staff>? Staff { get; set; } = new List<Staff>();
}

