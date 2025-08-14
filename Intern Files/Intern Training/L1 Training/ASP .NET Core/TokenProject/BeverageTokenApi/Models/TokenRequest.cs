using System.ComponentModel.DataAnnotations.Schema;

namespace BeverageTokenApi.Models;

public class TokenRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string BeverageType { get; set; } = null!;
    public DateTime RequestTime { get; set; }
    public bool IsClaimed { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
}
