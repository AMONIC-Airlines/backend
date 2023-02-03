using Domain.Models;

namespace Domain.IRepositories;

public interface IScheduleRepository : IBaseRepository<Schedule>
{
    Task<Schedule?> GetByDateAndFlightNumber(DateOnly date, string flightNumber);
}
