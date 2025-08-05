using System.ComponentModel.DataAnnotations;

namespace OnlineSalonManagementSystem.Models;

public partial class Appointment
{
    [Key]
    [Display(Name = "Appointment ID")]
    public int Id { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [Display(Name = "Date and Time")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime Date { get; set; }

    [Display(Name = "Service ID")]
    public int ServiceId { get; set; }

    [Display(Name = "Customer ID")]
    public int CustomerId { get; set; }

    [Display(Name = "Staff ID")]
    public int StaffId { get; set; }

    [Display(Name = "Customer")]
    public virtual Customer? Customer { get; set; }

    [Display(Name = "Service")]
    public virtual Service? Service { get; set; }

    [Display(Name = "Staff")]
    public virtual Staff? Staff { get; set; }
}

