using System.ComponentModel.DataAnnotations;

namespace EmpManagementSystemCore.Entity
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Department { get; set; }

        public DateTime DateOfJoining { get; set; }
    }
}
