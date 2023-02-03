using Database.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Database.Repositories;

public class RouteRepository : IRouteRepository
{
    private readonly ApplicationContext _db;

    public RouteRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<Route> Create(Route route)
    {
        await _db.Routes.AddAsync(route);

        await Save();

        return route;
    }

    public async Task<Route?> Get(int Id)
    {
        return await _db.Routes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<List<Route>> GetAll()
    {
        return await _db.Routes.ToListAsync();
    }

    public async Task<Route> Delete(int id)
    {
        var route = await _db.Routes.AsNoTracking().FirstAsync(x => x.Id == id);

        _db.Routes.Remove(route);
        await Save();

        return route;
    }

    public async Task<Route> Update(Route route)
    {
        _db.Routes.Update(route);
        await Save();

        return route;
    }

    public async Task<List<Route>> GetByDepartureAndArrivalAirportId(int departureId, int arrivalId)
    {
        return await _db.Routes
            .AsNoTracking()
            .Where(x => x.DepartureAirportId == departureId && x.ArrivalAirportId == arrivalId)
            .ToListAsync();
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}
