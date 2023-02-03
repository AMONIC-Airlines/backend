namespace Database.Models;

public class AvailableSpace
{
    public int Id { get; set; }

    public int ScheduleId { get; set; }

    public int? OccipiedEconomSeats { get; set; }

    public int? OccupiedBusinesssSeats { get; set; }

    public int? OccupiedFirstClassSeats { get; set; }

    public virtual Schedule Schedule { get; set; } = null!;
}
