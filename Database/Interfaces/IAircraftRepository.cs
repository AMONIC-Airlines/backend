using Domain.Models;

namespace Domain.IRepositories;

public interface IAircraftRepository : IBaseRepository<Aircraft>
{
    Task<Aircraft?> GetByName(string name);
}
