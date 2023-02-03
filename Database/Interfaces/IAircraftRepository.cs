using Domain.Models;

namespace Domain.IRepositories;

public interface IAircraftRepository : IBaseRepository<Aircraft>
{
    Task<List<Aircraft>> GetByName();
}