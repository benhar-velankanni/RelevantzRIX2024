using System.ComponentModel.DataAnnotations;

namespace SkillTransferApp.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        public string? StringName { get; set; }

        public int Proficiency { get; set; }

        public ICollection<Session>? Sessions { get; set; }
    }
}
