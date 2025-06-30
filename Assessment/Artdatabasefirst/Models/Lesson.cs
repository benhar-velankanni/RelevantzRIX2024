using System;
using System.Collections.Generic;

namespace Artdatabasefirst.Models;

public partial class Lesson
{
    public int LessonId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int UserId { get; set; }

    

    public virtual User User { get; set; } = null!;
}
