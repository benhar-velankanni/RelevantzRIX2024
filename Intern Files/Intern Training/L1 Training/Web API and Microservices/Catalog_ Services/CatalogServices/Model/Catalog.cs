using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace CatalogServices.Model
{
    public class Catalog
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}