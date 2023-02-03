using Database.Models;

namespace Database.Interfaces;

public interface IRouteRepository : IBaseRepository<Route>
{
    Task<List<Route>> GetByDepartureAndArrivalAirportId(int departureId, int arrivalId);
}
