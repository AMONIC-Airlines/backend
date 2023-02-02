using Domain.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;
public class CountryRepository : ICountryRepository 
{
    private readonly ApplicationContext _db;

    public CountryRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Country country)
    {
        if (_db.Countries != null)
        {
            await _db.Countries.AddAsync(country);
        }
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Country> Get(int id)
    {
        return await _db.Countries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Country>> Select()
    {
        return await _db.Countries.ToListAsync();
    }

    public async Task<bool> Delete(Country country)
    {
        _db.Countries.Remove(country);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Country> Update(Country country)
    {
        _db.Countries.Update(country);
        await _db.SaveChangesAsync();

        return country;
    }

    public async Task<Country> GetByName(string name)
    {
        return await _db.Countries.FirstOrDefaultAsync(x => x.Name == name);
    }
}
