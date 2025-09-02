using System.ComponentModel.DataAnnotations;

namespace SkillTransferApp.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        public string? SessionName { get; set; }

        public string? SkillName { get; set; }

        public ICollection<Skill>? Skills { get; set; }

        public DateTime DateTime { get; set; }
    }
}
