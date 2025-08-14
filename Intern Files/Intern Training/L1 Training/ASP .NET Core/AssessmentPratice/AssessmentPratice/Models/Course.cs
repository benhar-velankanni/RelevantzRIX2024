using System;
using System.Collections.Generic;

namespace AssessmentPratice.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public float? CoursePrice { get; set; }

    public virtual Enroll? Enroll { get; set; }
}
