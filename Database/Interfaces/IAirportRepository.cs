using Database.Models;

namespace Database.Interfaces;

public interface IAirportRepository : IBaseRepository<Airport>
{
    Task<Airport?> GetByName(string name);
}
