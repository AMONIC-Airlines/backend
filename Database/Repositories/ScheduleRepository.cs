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

    public async Task<Schedule?> GetByDateAndFlightNumber(DateOnly date, string flightNumber)
    {
        return await _db.Schedules.OrderBy(x => x.Date).ThenBy(x => x.Time).ThenBy(x => x.EconomyPrice).ThenBy(x => x.Confirmed).AsNoTracking().FirstOrDefaultAsync(x => x.Date == date && x.FlightNumber == flightNumber);
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}
