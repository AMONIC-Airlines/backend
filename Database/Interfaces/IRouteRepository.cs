using Domain.Models;


namespace Domain.IRepositories;

public interface IRouteRepository : IBaseRepository<Route>
{
    Task<List<Route>> GetByDepartureAirportId();
}
