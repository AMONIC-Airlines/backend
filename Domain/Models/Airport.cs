using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Airport
{
    public int Id { get; set; }

    [Required]
    public int CountryId { get; set; }

    [Required]
    public string IATACode { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
}
