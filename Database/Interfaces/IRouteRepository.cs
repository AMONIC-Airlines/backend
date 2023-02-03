using Database.Models;

namespace Database.Interfaces;

public interface IRouteRepository : IBaseRepository<Route>
{
    Task<Route?> GetByDepartureAndArrivalAirportId(int departureId, int arrivalId);
}
