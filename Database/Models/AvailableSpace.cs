namespace Database.Models;

public class AvailableSpace
{
    public int ScheduleId { get; set; }
    public int OccipiedEconomSeats { get; set; } = 0;
    public int OccupiedBusinesssSeats { get; set; } = 0;
    public int OccupiedFirstClassSeats { get; set; } = 0;
}
