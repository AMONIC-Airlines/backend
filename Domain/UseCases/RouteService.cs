using Database.Interfaces;
using Domain.Logic;
using Database.Models;

namespace Domain.UseCases;
public class RouteService
{
    private IRouteRepository _db;

    public RouteService(IRouteRepository db)
    {
        _db = db;
    }

    public async Task<Result<Route>> GetRoute(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<Route>("Route doesn't exist.");
            }

            return Result.Ok<Route>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Route>();
        }
    }

    public async Task<Result<Route>> DeleteRoute(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<Route>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Route>();
        }
    }

    public async Task<Result<Route>> UpdateRoute(Route route)
    {
        try
        {
            var success = await _db.Update(route);

            return Result.Ok<Route>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Route>();
        }
    }

    public async Task<Result<Route>> CreateRoute(Route route)
    {
        try
        {
            var item = await _db.Get(route.Id);

            if (item is not null)
            {
                return Result.Fail<Route>("Route already exists.");
            }

            var success = await _db.Create(route);

            return Result.Ok<Route>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Route>();
        }
    }

    public async Task<Result<List<Route>>> GetAllRoutes()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<Route>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Route>>();
        }
    }

    public async Task<Result<Route>> GetByDepartureAndArrivalAirportId(int departureId, int arrivalId)
    {
        try
        {
            var success = await _db.GetByDepartureAndArrivalAirportId(departureId, arrivalId);

            return Result.Ok<Route>(success!);
        }
        catch (Exception) 
        { 
            return Result.Exception<Route>();
        }
    }

}
