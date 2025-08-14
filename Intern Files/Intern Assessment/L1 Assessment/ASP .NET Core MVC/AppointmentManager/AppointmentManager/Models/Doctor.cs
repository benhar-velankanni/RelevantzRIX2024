using System;
using System.Collections.Generic;

namespace AppointmentManager.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? DoctorName { get; set; }

    public string? Specialization { get; set; }

    public string? Availability { get; set; }

    public virtual Appointment? Appointment { get; set; }
}

