using Database.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Database.Repositories;

public class AvailableSpaceRepository : IAvailableSpaceRepository   
{
    private readonly ApplicationContext _db;

    public AvailableSpaceRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<AvailableSpace> Create(AvailableSpace availableSpace)
    {
        await _db.AvailableSpaces.AddAsync(availableSpace);

        await Save();

        return availableSpace;
    }
    public async Task<List<AvailableSpace>> GetAll()
    {
        return await _db.AvailableSpaces.ToListAsync();
    }

    public async Task<AvailableSpace> Update(AvailableSpace availableSpace)
    {
        _db.AvailableSpaces.Update(availableSpace);
        await Save();

        return availableSpace;
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }

    public async Task<AvailableSpace?> GetByScheduleId(int scheduleId)
    {
        return await _db.AvailableSpaces.FirstOrDefaultAsync(x => x.ScheduleId == scheduleId);
    }

    Task<AvailableSpace?> IBaseRepository<AvailableSpace>.Get(int Id)
    {
        throw new NotImplementedException();
    }

    Task<AvailableSpace> IBaseRepository<AvailableSpace>.Delete(int id)
    {
        throw new NotImplementedException();
    }
}
