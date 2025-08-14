using System.ComponentModel.DataAnnotations;

namespace TeacherAPI.Model
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string DateOfJoining { get; set; }
    }
}
