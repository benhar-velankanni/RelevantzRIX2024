using System.ComponentModel.DataAnnotations;

namespace GlossaryManagementService.Model
{
    public class GlossaryManagement
    {
        [Key]
        public int Id { get; set; }

        public string Word { get; set; }

        public string Meaning { get; set; }

        public string? Notes { get; set; }
    }
}
