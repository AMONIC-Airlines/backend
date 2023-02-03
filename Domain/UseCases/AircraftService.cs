using Database.Interfaces;
using Domain.Logic;
using Database.Models;

namespace Domain.UseCases;
public class AircraftService
{
    private IAircraftRepository _db;

    public AircraftService(IAircraftRepository db)
    {
        _db = db;
    }

    public async Task<Result<Aircraft>> GetAircraft(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<Aircraft>("Aircraft doesn't exist.");
            }

            return Result.Ok<Aircraft>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Aircraft>();
        }
    }

    public async Task<Result<Aircraft>> DeleteAircraft(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<Aircraft>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Aircraft>();
        }
    }

    public async Task<Result<Aircraft>> UpdateAircraft(Aircraft aircraft)
    {
        try
        {
            var success = await _db.Update(aircraft);

            return Result.Ok<Aircraft>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Aircraft>();
        }
    }

    public async Task<Result<Aircraft>> CreateAircraft(Aircraft aircraft)
    {
        try
        {
            var item = await _db.Get(aircraft.Id);

            if (item is not null)
            {
                return Result.Fail<Aircraft>("Aircraft already exists.");
            }

            var success = await _db.Create(aircraft);

            return Result.Ok<Aircraft>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Aircraft>();
        }
    }

    public async Task<Result<List<Aircraft>>> GetAllAircrafts()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<Aircraft>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Aircraft>>();
        }
    }

}
