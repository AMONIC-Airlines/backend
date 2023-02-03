using Domain.Models;

namespace Domain.IRepositories;

public interface IAirportRepository : IBaseRepository<Airport>
{
    Task<List<Airport>> GetByName();
}

