using System.ComponentModel.DataAnnotations;

namespace ShipmentManagementWebApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; } // Plain text for simplicity
        public string? Role { get; set; } = "User"; // Default role
    }

}
