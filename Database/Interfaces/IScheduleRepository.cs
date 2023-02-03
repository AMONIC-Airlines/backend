using Domain.Models;

namespace Domain.IRepositories;

public interface IScheduleRepository : IBaseRepository<Schedule>
{
    Task<List<Schedule>> GetByFlightNumber();
}
