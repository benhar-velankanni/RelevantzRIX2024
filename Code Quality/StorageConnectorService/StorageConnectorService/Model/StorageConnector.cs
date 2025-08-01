using System.ComponentModel.DataAnnotations;
namespace StorageConnectorService.Model
{
    public class StorageConnector
    {
        [Key]
        public int StorageConnectorId { get; set; }
        [Required]
        public string StorageConnectorName { get; set; }
        [Required]
        public string StorageConnectorDescription { get; set; }
       
       

    }
}
