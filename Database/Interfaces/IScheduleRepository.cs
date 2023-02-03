using Database.Models;

namespace Database.Interfaces;

public interface IScheduleRepository : IBaseRepository<Schedule>
{
    Task<Schedule?> GetByDateAndFlightNumber(DateOnly date, string flightNumber);
}
