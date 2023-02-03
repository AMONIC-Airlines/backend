using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Aircraft
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string? MakeModel { get; set; }

    [Required]
    public int TotalSeats { get; set; }

    [Required]
    public int EconomySeats { get; set; }

    [Required]
    public int BusinessSeats { get; set; }
}
