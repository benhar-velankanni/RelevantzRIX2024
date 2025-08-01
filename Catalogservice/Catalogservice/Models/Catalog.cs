using System.ComponentModel.DataAnnotations;
namespace Catalogservice.Models
{
    public class Catalog
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
    
    }
}