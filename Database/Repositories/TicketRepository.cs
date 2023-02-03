using Database.Models;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;  

public class TicketRepository : ITicketRepository  
{
    private readonly ApplicationContext _db;

    public TicketRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<Ticket> Create(Ticket ticket)
    {
        await _db.Tickets.AddAsync(ticket);

        await Save();

        return ticket;
    }

    public async Task<Ticket?> Get(int id)
    {
        return await _db.Tickets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Ticket>> GetAll()
    {
        return await _db.Tickets.ToListAsync();
    }

    public async Task<Ticket> Delete(int id)
    {
        var ticket = await _db.Tickets.AsNoTracking().FirstAsync(x => x.Id == id);

        _db.Tickets.Remove(ticket);
        await Save();

        return ticket;
    }

    public async Task<Ticket> Update(Ticket ticket)
    {
        _db.Tickets.Update(ticket);
        await Save();

        return ticket;
    }

    public async Task<List<Ticket>> GetByDate(DateOnly date)
    {
        return await _db.Tickets.Where(x => x.Schedule.Date == date).ToListAsync();
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}
