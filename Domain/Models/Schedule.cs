using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Schedule
{
    public int Id { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public TimeOnly Time { get; set; }

    [Required]
    public int AircraftId { get; set; }

    [Required]
    public int RouteId { get; set; }

    [Required]
    [MaxLength(50)]
    public string? FlightNumber { get; set; }

    [Required]
    public double EconomyPrice { get; set; }

    [Required]
    public bool Confirmed { get; set; }


}
