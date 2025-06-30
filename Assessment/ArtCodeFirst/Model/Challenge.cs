using System;
using System.Collections.Generic;

namespace ArtCodefirst.Models;

public partial class Challenge
{
    public int ChallengeId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int UserId { get; set; }

    

    public virtual User User { get; set; } = null!;
}
