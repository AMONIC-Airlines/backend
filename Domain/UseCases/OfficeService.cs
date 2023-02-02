using Domain.Logic;
using Domain.IRepositories;
using Domain.Models;

namespace Domain.UseCases;

public class OfficeService
{
    private IOfficeRepository _db;

    public OfficeService(IOfficeRepository db)
    {
        _db = db;
    }

    public async Task<Result<Office>> GetOffice(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<Office>("Office doesn't exist.");
            }

            return Result.Ok<Office>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Office>();
        }
    }

    public async Task<Result<Office>> DeleteOffice(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<Office>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Office>();
        }
    }

    public async Task<Result<Office>> UpdateOffice(Office office)
    {
        try
        {
            var success = await _db.Update(office);

            return Result.Ok<Office>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Office>();
        }
    }

    public async Task<Result<Office>> CreateOffice(Office office)
    {
        try
        {
            var item = await _db.Get(office.Id);

            if (item is not null)
            {
                return Result.Fail<Office>("Office already exists");
            }

            var success = await _db.Create(office);

            return Result.Ok<Office>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Office>();
        }
    }

    public async Task<Result<List<Office>>> GetAllOffices()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<Office>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Office>>();
        }
    }
}
