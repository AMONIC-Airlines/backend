using Database.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;
public class AirportRepository : IBaseRepository<Airport>
{
    private readonly ApplicationContext _db;

    public AirportRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<Airport> Create(Airport airport)
    {
        await _db.Airports.AddAsync(airport);

        await Save();

        return airport;
    }

    public async Task<Airport?> Get(int Id)
    {
        return await _db.Airports.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<List<Airport>> GetAll()
    {
        return await _db.Airports.ToListAsync();
    }

    public async Task<Airport> Delete(int id)
    {
        var airport = await _db.Airports.AsNoTracking().FirstAsync(x => x.Id == id);

        _db.Airports.Remove(airport);
        await Save();

        return airport;
    }

    public async Task<Airport> Update(Airport airport)
    {
        _db.Airports.Update(airport);
        await Save();

        return airport;
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}
