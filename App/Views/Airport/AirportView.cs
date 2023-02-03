namespace App.Views.Airport;

public partial class AirportView
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public string Iatacode { get; set; } = null!;
    public string? Name { get; set; }
}
