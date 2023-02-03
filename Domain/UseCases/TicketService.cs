using Domain.Logic;
using Database.Interfaces;
using Database.Models;

namespace Domain.UseCases; 

public class TicketService
{
    private ITicketRepository _db;

    public TicketService(ITicketRepository db)
    {
        _db = db;
    }

    public async Task<Result<Ticket>> GetTicket(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<Ticket>("Ticket doesn't exist.");
            }

            return Result.Ok<Ticket>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Ticket>();
        }
    }

    public async Task<Result<Ticket>> DeleteTicket(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<Ticket>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Ticket>();
        }
    }

    public async Task<Result<Ticket>> UpdateTicket(Ticket ticket)
    {
        try
        {
            var success = await _db.Update(ticket);

            return Result.Ok<Ticket>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Ticket>();
        }
    }

    public async Task<Result<Ticket>> CreateTicket(Ticket ticket)
    {
        try
        {
            var item = await _db.Get(ticket.Id);

            if (item is not null)
            {
                return Result.Fail<Ticket>("Ticket already exists.");
            }

            var success = await _db.Create(ticket);

            return Result.Ok<Ticket>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Ticket>();
        }
    }

    public async Task<Result<List<Ticket>>> GetAllTickets()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<Ticket>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Ticket>>();
        }
    }

    public async Task<Result<List<Ticket>>> GetByDate(DateOnly date)
    {
        try
        {
            var success = await _db.GetByDate(date);

            return Result.Ok<List<Ticket>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Ticket>>();
        }
    }
}
