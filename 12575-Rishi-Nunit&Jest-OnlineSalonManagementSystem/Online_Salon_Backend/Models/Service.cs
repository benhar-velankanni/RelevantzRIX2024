using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSalonManagementSystem.Models;

public partial class Service
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }

    public int SalonId { get; set; }

    public virtual ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();

    public virtual Salon? Salon { get; set; } = null!;
}

