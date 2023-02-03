using Domain.Logic;
using Database.Interfaces;
using Database.Models;

namespace Domain.UseCases;

public class CabintypeService
{
    private ICabintypeRepository _db;

    public CabintypeService(ICabintypeRepository db)
    {
        _db = db;
    }

    public async Task<Result<Cabintype>> GetCabintype(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<Cabintype>("Cabintype doesn't exist.");
            }

            return Result.Ok<Cabintype>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Cabintype>();
        }
    }

    public async Task<Result<Cabintype>> DeleteCabintype(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<Cabintype>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Cabintype>();
        }
    }

    public async Task<Result<Cabintype>> UpdateCabintype(Cabintype cabintype)
    {
        try
        {
            var success = await _db.Update(cabintype);

            return Result.Ok<Cabintype>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Cabintype>();
        }
    }

    public async Task<Result<Cabintype>> CreateCabintype(Cabintype cabintype)
    {
        try
        {
            var item = await _db.Get(cabintype.Id);

            if (item is not null)
            {
                return Result.Fail<Cabintype>("Cabintype already exists.");
            }

            var success = await _db.Create(cabintype);

            return Result.Ok<Cabintype>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Cabintype>();
        }
    }

    public async Task<Result<List<Cabintype>>> GetAllCabintypes()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<Cabintype>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Cabintype>>();
        }
    }
}
