using System.ComponentModel.DataAnnotations;

namespace ShipmentManagementWebApi.Models
{
    public class Shipment
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Address { get; set; }
    }
}
