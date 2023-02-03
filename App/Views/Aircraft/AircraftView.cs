namespace App.Views.Aircraft;

public partial class AircraftView
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? MakeModel { get; set; }
    public int TotalSeats { get; set; }
    public int EconomySeats { get; set; }
    public int BusinessSeats { get; set; }
}
