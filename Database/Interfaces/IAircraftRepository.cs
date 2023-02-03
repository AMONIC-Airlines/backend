using Database.Models;

namespace Database.Interfaces;

public interface IAircraftRepository : IBaseRepository<Aircraft>
{
    Task<Aircraft?> GetByName(string name);
}
