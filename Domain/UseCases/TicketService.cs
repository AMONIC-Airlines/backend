using Domain.Logic;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using System.Runtime.ExceptionServices;

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

    public async Task<Result<Ticket>> BookTicket(List<Ticket> tickets)
    {
        try
        {
            if (tickets.Count > tickets[0].Schedule.Aircraft.TotalSeats - ScheduleRepository.occupiedPlaces[tickets[0].ScheduleId])
            {
                return Result.Fail<Ticket>("There are not so many seats on the plane.");
            }

            ScheduleRepository.occupiedPlaces[tickets[0].ScheduleId] += tickets.Count;

            tickets[0].BookingReference = BookingReferenceGeneration.GenerateBookingReference();
            var success = await _db.Create(tickets[0]); ;

            for (int i = 1; i < tickets.Count; i++)
            {
                tickets[i].BookingReference = BookingReferenceGeneration.GenerateBookingReference();

                success = await _db.Create(tickets[i]);
            }

            return Result.Ok<Ticket>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Ticket>();
        }
    }
}
