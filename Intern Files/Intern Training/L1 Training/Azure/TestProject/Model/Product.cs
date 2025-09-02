using System.ComponentModel.DataAnnotations;

namespace TestProject.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public float Price { get; set; }
}
