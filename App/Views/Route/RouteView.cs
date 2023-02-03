namespace App.Views.Route;

public partial class RouteView
{
    public int Id { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public int Distance { get; set; }
    public int FlightTime { get; set; }
}
