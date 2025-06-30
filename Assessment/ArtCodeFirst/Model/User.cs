using System;
using System.Collections.Generic;


namespace ArtCodefirst.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Challenge> Challenges { get; set; } = new List<Challenge>();
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
