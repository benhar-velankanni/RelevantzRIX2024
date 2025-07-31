using System.ComponentModel.DataAnnotations;

namespace CRUD.Model
{
    public class Student
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public int PhoneNo { get; set; }
        

    }
}
