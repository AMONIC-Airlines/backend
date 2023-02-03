using Domain.Logic;
using Domain.IRepositories;
using Domain.Models;

namespace Domain.UseCases;
public class AirportService
{
    private IAirportRepository _db;

    public AirportService(IAirportRepository db)
    {
        _db = db;
    }

    public async Task<Result<Airport>> GetAirport(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<Airport>("Airport doesn't exist.");
            }

            return Result.Ok<Airport>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Airport>();
        }
    }

    public async Task<Result<Airport>> DeleteAirport(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<Airport>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Airport>();
        }
    }

    public async Task<Result<Airport>> UpdateAirport(Airport airport)
    {
        try
        {
            var success = await _db.Update(airport);

            return Result.Ok<Airport>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Airport>();
        }
    }

    public async Task<Result<Airport>> CreateAirport(Airport airport)
    {
        try
        {
            var item = await _db.Get(airport.Id);

            if (item is not null)
            {
                return Result.Fail<Airport>("Airport already exists.");
            }

            var success = await _db.Create(airport);

            return Result.Ok<Airport>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Airport>();
        }
    }

    public async Task<Result<List<Airport>>> GetAllAirports()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<Airport>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Airport>>();
        }
    }

}
