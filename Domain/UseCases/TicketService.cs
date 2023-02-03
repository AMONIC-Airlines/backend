using Domain.Logic;
using Database.Interfaces;
using Database.Models;

namespace Domain.UseCases;

public class TicketService
{
    private ITicketRepository _db;
    private IAvailableSpaceRepository _dbAvailableSpace;
    private IScheduleRepository _dbSchedule;
    private IAircraftRepository _dbAircraft;

    public TicketService(
        ITicketRepository db,
        IAvailableSpaceRepository dbAvailableSpace,
        IScheduleRepository dbSchedule,
        IAircraftRepository dbAircraft
    )
    {
        _db = db;
        _dbAvailableSpace = dbAvailableSpace;
        _dbSchedule = dbSchedule;
        _dbAircraft = dbAircraft;
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

    public async Task<Result<List<Ticket>>> BookTicket(List<Ticket> tickets)
    {
        try
        {
            var schedule = await _dbSchedule.Get(tickets[0].ScheduleId);

            if (schedule is null)
            {
                return Result.Fail<List<Ticket>>("Schedule doesn't exist.");
            }

            var aircraft = await _dbAircraft.Get(schedule.AircraftId);

            if (aircraft is null)
            {
                return Result.Fail<List<Ticket>>("Aircraft doesn't exist.");
            }

            var available = await _dbAvailableSpace.GetByScheduleId(tickets[0].ScheduleId);

            if (available is null)
            {
                available = await _dbAvailableSpace.Create(
                    new AvailableSpace { ScheduleId = tickets[0].ScheduleId }
                );
            }

            List<Ticket> result = new List<Ticket>();

            for (int i = 0; i < tickets.Count; i++)
            {
                if (tickets[i].CabinTypeId == 1) // Econom
                {
                    int remainingEconomSeats =
                        aircraft.EconomySeats - available!.OccipiedEconomSeats.GetValueOrDefault();

                    if (tickets.Count > remainingEconomSeats)
                    {
                        return Result.Fail<List<Ticket>>(
                            "There are not so many Econom seats on the plane. Available: "
                                + remainingEconomSeats
                        );
                    }

                    available!.OccipiedEconomSeats += tickets.Count;
                }
                else if (tickets[i].CabinTypeId == 2) // Business
                {
                    int remainingBusinessSeats =
                        aircraft.BusinessSeats
                        - available!.OccupiedBusinesssSeats.GetValueOrDefault();

                    if (tickets.Count > remainingBusinessSeats)
                    {
                        return Result.Fail<List<Ticket>>(
                            "There are not so many Business seats on the plane. Available: "
                                + remainingBusinessSeats
                        );
                    }

                    available.OccupiedBusinesssSeats += tickets.Count;
                }
                else // FirstClass
                {
                    int allFirstClassSeats =
                        aircraft.TotalSeats - (aircraft.EconomySeats + aircraft.BusinessSeats);
                    int remainingFirstClassSeats =
                        allFirstClassSeats - available!.OccupiedFirstClassSeats.GetValueOrDefault();

                    if (tickets.Count > remainingFirstClassSeats)
                    {
                        return Result.Fail<List<Ticket>>(
                            "There are not so many First Class seats on the plane. Available: "
                                + remainingFirstClassSeats
                        );
                    }

                    available.OccupiedFirstClassSeats += tickets.Count;
                }

                tickets[i].BookingReference = BookingReferenceGeneration.GenerateBookingReference();

                var success = await _db.Create(tickets[i]);
                result.Add(success);
            }

            return Result.Ok<List<Ticket>>(result);
        }
        catch (Exception)
        {
            return Result.Exception<List<Ticket>>();
        }
    }
}
