using Database.Models;

namespace Database.Interfaces;

public interface IAvailableSpaceRepository : IBaseRepository<AvailableSpace>
{
    Task<AvailableSpace?> GetByScheduleId(int id);
}
