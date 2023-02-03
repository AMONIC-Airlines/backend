using Database.Models;
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

    public async Task<Country> Create(Country country)
    {
        await _db.Countries.AddAsync(country);

        await Save();

        return country;
    }

    public async Task<Country?> Get(int id)
    {
        return await _db.Countries.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Country>> GetAll()
    {
        return await _db.Countries.ToListAsync();
    }

    public async Task<Country> Delete(int id)
    {
        var country = await _db.Countries.AsNoTracking().FirstAsync(x => x.Id == id);

        _db.Countries.Remove(country);
        await Save();

        return country;
    }

    public async Task<Country> Update(Country country)
    {
        _db.Countries.Update(country);
        await Save();

        return country;
    }

    public async Task<Country?> GetByName(string name)
    {
        return await _db.Countries.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}
