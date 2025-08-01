using System.ComponentModel.DataAnnotations;
namespace Services.Model
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
