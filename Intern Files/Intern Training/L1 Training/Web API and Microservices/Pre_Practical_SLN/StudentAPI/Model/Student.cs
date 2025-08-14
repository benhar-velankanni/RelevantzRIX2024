using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ClassAndSection { get; set; }

        public string DateOfBirth { get; set; }

    }
}
