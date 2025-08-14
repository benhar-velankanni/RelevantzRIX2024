using System;
using System.Collections.Generic;

namespace AssessmentPratice.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public int? StudentAge { get; set; }

    public DateOnly? StudentDob { get; set; }

    public virtual Enroll? Enroll { get; set; }
}
