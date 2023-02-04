using Domain.Logic;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;

namespace Domain.UseCases;

public class TicketService
{
    private ITicketRepository _db;

    private IAvailableSpaceRepository _dbAvailableSpace;

    public TicketService(ITicketRepository db, IAvailableSpaceRepository dbAvailableSpace)
    {
        _db = db;
        _dbAvailableSpace = dbAvailableSpace;
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

    public async Task<Result<List<Ticket>>> GetByUserId(int userId)
    {
        try
        {
            var success = await _db.GetByUserId(userId);

            return Result.Ok<List<Ticket>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Ticket>>();
        }
    }

    public async Task<Result<Ticket>> ConfirmTicket(int id)
    {
        try
        {
            var ticket = await _db.Get(id);

            if (ticket is null)
            {
                return Result.Fail<Ticket>("Ticket doesn't exist.");
            }

            ticket!.Confirmed = true;

            var success = await _db.Update(ticket);

            return Result.Ok<Ticket>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Ticket>();
        }
    }

    public async Task<Result<Ticket>> BookTicket(List<Ticket> tickets)
    {
        try
        {
            var available = _dbAvailableSpace.GetByScheduleId(tickets[0].ScheduleId).Result;

            if (tickets[0].CabinTypeId == 1)  // Econom 
            {
                int remainingEconomSeats = tickets[0].Schedule.Aircraft.EconomySeats - available!.OccipiedEconomSeats;

                if (tickets.Count > remainingEconomSeats)
                {
                    return Result.Fail<Ticket>("There are not so many Econom seats on the plane. Available: " + remainingEconomSeats);
                }

                tickets[0].BookingReference = BookingReferenceGeneration.GenerateBookingReference();
                var success = await _db.Create(tickets[0]);

                for (int i = 1; i < tickets.Count; i++)
                {
                    tickets[i].BookingReference = BookingReferenceGeneration.GenerateBookingReference();

                    success = await _db.Create(tickets[i]);
                }

                available.OccipiedEconomSeats += tickets.Count;

                return Result.Ok<Ticket>(success);
            }
            else if (tickets[0].CabinTypeId == 1)   // Business
            {
                int remainingBusinessSeats = tickets[0].Schedule.Aircraft.BusinessSeats - available!.OccupiedBusinesssSeats;

                if (tickets.Count > remainingBusinessSeats)
                {
                    return Result.Fail<Ticket>("There are not so many Business seats on the plane. Available: " + remainingBusinessSeats);
                }

                tickets[0].BookingReference = BookingReferenceGeneration.GenerateBookingReference();
                var success = await _db.Create(tickets[0]);

                for (int i = 1; i < tickets.Count; i++)
                {
                    tickets[i].BookingReference = BookingReferenceGeneration.GenerateBookingReference();

                    success = await _db.Create(tickets[i]);
                }

                available.OccupiedBusinesssSeats += tickets.Count;

                return Result.Ok<Ticket>(success);
            }
            else
            {
                int allFirstClassSeats = tickets[0].Schedule.Aircraft.TotalSeats - (tickets[0].Schedule.Aircraft.EconomySeats + tickets[0].Schedule.Aircraft.BusinessSeats);
                int remainingFirstClassSeats = allFirstClassSeats - available!.OccupiedFirstClassSeats;

                if (tickets.Count > remainingFirstClassSeats)
                {
                    return Result.Fail<Ticket>("There are not so many First Class seats on the plane. Available: " + remainingFirstClassSeats);
                }

                tickets[0].BookingReference = BookingReferenceGeneration.GenerateBookingReference();
                var success = await _db.Create(tickets[0]);

                for (int i = 1; i < tickets.Count; i++)
                {
                    tickets[i].BookingReference = BookingReferenceGeneration.GenerateBookingReference();

                    success = await _db.Create(tickets[i]);
                }

                available.OccupiedFirstClassSeats += tickets.Count;

                return Result.Ok<Ticket>(success);
            }
        }
        catch (Exception)
        {
            return Result.Exception<Ticket>();
        }
    }
}
