using Database.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;  

public class CabintypeRepository : ICabintypeRepository
{
    private readonly ApplicationContext _db;

    public CabintypeRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<Cabintype> Create(Cabintype cabintype)
    {
        await _db.Cabintypes.AddAsync(cabintype);

        await Save();

        return cabintype;
    }

    public async Task<Cabintype?> Get(int id)
    {
        return await _db.Cabintypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Cabintype>> GetAll()
    {
        return await _db.Cabintypes.ToListAsync();
    }

    public async Task<Cabintype> Delete(int id)
    {
        var cabintype = await _db.Cabintypes.AsNoTracking().FirstAsync(x => x.Id == id);

        _db.Cabintypes.Remove(cabintype);
        await Save();

        return cabintype;
    }

    public async Task<Cabintype> Update(Cabintype cabintype)
    {
        _db.Cabintypes.Update(cabintype);
        await Save();

        return cabintype;
    }

    public async Task<Cabintype?> GetByName(string name)
    {
        return await _db.Cabintypes.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}
