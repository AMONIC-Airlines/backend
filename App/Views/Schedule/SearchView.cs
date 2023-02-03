using System.ComponentModel.DataAnnotations;

namespace App.Views.Schedule;

public class SearchView
{
    [Required]
    public int DepartureId { get; set; }

    [Required]
    public int ArrivalId { get; set; }

    [Required]
    public DateOnly Date { get; set; }
}
