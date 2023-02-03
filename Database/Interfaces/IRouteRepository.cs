using Domain.Models;


namespace Domain.IRepositories;

public interface IRouteRepository : IBaseRepository<Route>
{
    Task<Route?> GetByDepartureAndArrivalAirportId(int departureId, int arrivalId);
}
