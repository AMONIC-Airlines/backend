namespace App.Views.Schedule;

public class ScheduleView
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public int AircraftId { get; set; }
    public int RouteId { get; set; }
    public double EconomyPrice { get; set; }
    public bool Confirmed { get; set; }
    public string? FlightNumber { get; set; }
}
