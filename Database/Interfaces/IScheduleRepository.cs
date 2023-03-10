using Database.Models;

namespace Database.Interfaces;

public interface IScheduleRepository : IBaseRepository<Schedule>
{
    Task<List<Schedule>> GetByDate(DateOnly date);
}
