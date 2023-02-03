using Domain.Logic;
using Database.Interfaces;
using Database.Models;

namespace Domain.UseCases;

public class CountryService
{
    private ICountryRepository _db;

    public CountryService(ICountryRepository db)
    {
        _db = db;
    }

    public async Task<Result<Country>> GetCountry(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<Country>("Country doesn't exist.");
            }

            return Result.Ok<Country>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Country>();
        }
    }

    public async Task<Result<Country>> DeleteCountry(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<Country>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Country>();
        }
    }

    public async Task<Result<Country>> UpdateCountry(Country country)
    {
        try
        {
            var success = await _db.Update(country);

            return Result.Ok<Country>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Country>();
        }
    }

    public async Task<Result<Country>> CreateCountry(Country country)
    {
        try
        {
            var item = await _db.Get(country.Id);

            if (item is not null)
            {
                return Result.Fail<Country>("Country already exists.");
            }

            var success = await _db.Create(country);

            return Result.Ok<Country>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Country>();
        }
    }

    public async Task<Result<List<Country>>> GetAllCountries()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<Country>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Country>>();
        }
    }
}
