using Database.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly ApplicationContext _db;

    public ScheduleRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<Schedule> Create(Schedule schedule)
    {
        await _db.Schedules.AddAsync(schedule);

        await Save();

        return schedule;
    }

    public async Task<Schedule?> Get(int Id)
    {
        return await _db.Schedules.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<List<Schedule>> GetAll()
    {
        return await _db.Schedules.ToListAsync();
    }

    public async Task<Schedule> Delete(int id)
    {
        var schedule = await _db.Schedules.AsNoTracking().FirstAsync(x => x.Id == id);

        _db.Schedules.Remove(schedule);
        await Save();

        return schedule;
    }

    public async Task<Schedule> Update(Schedule schedule)
    {
        _db.Schedules.Update(schedule);
        await Save();

        return schedule;
    }

    public async Task<List<Schedule>> GetByDate(DateOnly date)
    {
        return await _db.Schedules.Where(x => x.Date == date).OrderBy(x => x.Date).ThenBy(x => x.Time).ThenBy(x => x.EconomyPrice).ThenBy(x => x.Confirmed).ToListAsync();
    }

    public async Task<List<Schedule>> GetByFlightNumber(string flightNumber)
    {
        return await _db.Schedules.Where(x => x.FlightNumber == flightNumber).OrderBy(x => x.Date).ThenBy(x => x.Time).ThenBy(x => x.EconomyPrice).ThenBy(x => x.Confirmed).ToListAsync();   
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}
