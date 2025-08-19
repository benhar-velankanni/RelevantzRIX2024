using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWebApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Contact {  get; set; }

        public string? Password { get; set; }
    }
}
