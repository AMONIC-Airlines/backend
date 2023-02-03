using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Route
{
    public int Id { get; set; }

    [Required]
    public int DepartureAirportId { get; set; }

    [Required]
    public int ArrivalAirportId { get; set; }

    [Required]
    public int Distance { get; set; }

    [Required]
    public TimeOnly FlightTime { get; set; }
}
