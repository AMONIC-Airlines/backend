using System.ComponentModel.DataAnnotations;

namespace App.Views.Ticket;

public class BookView
{
    [Required]
    public int ScheduleId { get; set; }

    [Required]
    public int CabinTypeId { get; set; }

    [Required]
    public string? Firstname { get; set; }

    [Required]
    public string? Lastname { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [Phone]
    public string? Phone { get; set; }

    [Required]
    public string? PassportNumber { get; set; }

    [Required]
    public int PassportCountryId { get; set; }
}
