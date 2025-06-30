using System;
using System.Collections.Generic;

namespace Secure_Document_Organiser_Code_First.Models;

public partial class Folder
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual User User { get; set; } = null!;
}

