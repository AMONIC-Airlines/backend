namespace App.Views.Ticket;

public class TicketView
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ScheduleId { get; set; }
    public int CabinTypeId { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? PassportNumber { get; set; }
    public int PassportCountryId { get; set; }
    public string? BookingReference { get; set; }
    public bool Confirmed { get; set; }
}
