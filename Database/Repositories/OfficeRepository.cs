using Domain.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;
public class OfficeRepository : IOfficeRepository
{
    private readonly ApplicationContext _db;

    public OfficeRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<Office> Create(Office office)
    {
        await _db.Offices.AddAsync(office);
        
        await Save();

        return office;
    }

    public async Task<Office?> Get(int id)
    {
        return await _db.Offices.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Office>> GetAll()
    {
        return await _db.Offices.ToListAsync();
    }

    public async Task<Office> Delete(int id)
    {
        var office = await _db.Offices.AsNoTracking().FirstAsync(x => x.Id == id);

        _db.Offices.Remove(office);
        await Save();

        return office;
    }

    public async Task<Office> Update(Office office)
    {
        _db.Offices.Update(office);
        await Save();

        return office;
    }

    public async Task<Office?> GetByCountryId(int id)
    {
        return await _db.Offices.AsNoTracking().FirstOrDefaultAsync(x => x.CountryId == id);
    }

    public async Task<Office?> GetByTitle(string title)
    {
        return await _db.Offices.AsNoTracking().FirstOrDefaultAsync(x => x.Title == title);
    }

    public async Task<Office?> GetByPhone(string phone)
    {
        return await _db.Offices.AsNoTracking().FirstOrDefaultAsync(x => x.Phone == phone);
    }

    public async Task<Office?> GetByContact(string contact)
    {
        return await _db.Offices.AsNoTracking().FirstOrDefaultAsync(x => x.Contact == contact);
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }

}
