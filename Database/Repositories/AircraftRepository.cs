using Database.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class AircraftRepository : IAircraftRepository
{
    private readonly ApplicationContext _db;

    public AircraftRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<Aircraft> Create(Aircraft aircraft)
    {
        await _db.Aircrafts.AddAsync(aircraft);

        await Save();

        return aircraft;
    }

    public async Task<Aircraft?> Get(int Id)
    {
        return await _db.Aircrafts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<List<Aircraft>> GetAll()
    {
        return await _db.Aircrafts.ToListAsync();
    }

    public async Task<Aircraft> Delete(int id)
    {
        var aircraft = await _db.Aircrafts.AsNoTracking().FirstAsync(x => x.Id == id);

        _db.Aircrafts.Remove(aircraft);
        await Save();

        return aircraft;
    }

    public async Task<Aircraft> Update(Aircraft aircraft)
    {
        _db.Aircrafts.Update(aircraft);
        await Save();

        return aircraft;
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }

    public async Task<Aircraft?> GetByName(string name)
    {
        return await _db.Aircrafts.FirstOrDefaultAsync(x => x.Name == name);
    }
}
