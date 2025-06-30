using System;
using System.Collections.Generic;

namespace Secure_Document_Organiser_DB_First.Models;

public partial class Document
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string EncryptedContent { get; set; } = null!;

    public int FolderId { get; set; }

    public virtual Folder Folder { get; set; } = null!;
}
