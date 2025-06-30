using System;
using System.Collections.Generic;

namespace Secure_Document_Organiser_DB_First.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Folder> Folders { get; set; } = new List<Folder>();
}
