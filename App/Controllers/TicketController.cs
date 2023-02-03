using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using App.Views.Ticket;
using Domain.UseCases;
using Database.Models;

namespace App.Controllers;

[ApiController]
[Route("ticket")]
[Produces("application/json")]
[Authorize]
public class TicketController : ControllerBase
{
    private readonly TicketService _ticketService;

    public TicketController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<TicketView>>> HandleGetAllUserTickets()
    {
        var result = await _ticketService.GetByUserId(GetId());

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        var list = new List<TicketView>();

        foreach (var it in result.Value!)
        {
            list.Add(
                new TicketView
                {
                    Id = it.Id,
                    UserId = it.UserId,
                    ScheduleId = it.ScheduleId,
                    CabinTypeId = it.CabinTypeId,
                    Firstname = it.Firstname,
                    Lastname = it.Lastname,
                    Email = it.Email,
                    Phone = it.Phone,
                    PassportNumber = it.PassportNumber,
                    PassportCountryId = it.PassportCountryId,
                    BookingReference = it.BookingReference,
                    Confirmed = it.Confirmed
                }
            );
        }

        return Ok(list);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TicketView>> HandleConfirmTicket(int id)
    {
        var ticket = await _ticketService.GetTicket(id);

        if (ticket.IsException)
        {
            return NotFound();
        }

        if (ticket.IsFailure)
        {
            return BadRequest(ticket.Error);
        }

        if (ticket.Value!.UserId != GetId())
        {
            return BadRequest("Not your ticket.");
        }

        var result = await _ticketService.ConfirmTicket(id);

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(
            new TicketView
            {
                Id = result.Value!.Id,
                UserId = result.Value.UserId,
                ScheduleId = result.Value.ScheduleId,
                CabinTypeId = result.Value.CabinTypeId,
                Firstname = result.Value.Firstname,
                Lastname = result.Value.Lastname,
                Email = result.Value.Email,
                Phone = result.Value.Phone,
                PassportNumber = result.Value.PassportNumber,
                PassportCountryId = result.Value.PassportCountryId,
                BookingReference = result.Value.BookingReference,
                Confirmed = result.Value.Confirmed
            }
        );
    }

    [HttpPost]
    public async Task<ActionResult<List<TicketView>>> HandleBookTicket([FromBody] BookView[] data)
    {
        var tickets = new List<Ticket>();

        foreach (var it in data)
        {
            tickets.Add(
                new Ticket
                {
                    UserId = GetId(),
                    ScheduleId = it.ScheduleId,
                    CabinTypeId = it.CabinTypeId,
                    Firstname = it.Firstname!,
                    Lastname = it.Lastname!,
                    Email = it.Email,
                    Phone = it.Phone!,
                    PassportNumber = it.PassportNumber!,
                    PassportCountryId = it.PassportCountryId
                }
            );
        }

        var result = await _ticketService.BookTicket(tickets);

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        var list = new List<TicketView>();

        foreach (var it in result.Value!)
        {
            list.Add(
                new TicketView
                {
                    Id = it.Id,
                    UserId = it.UserId,
                    ScheduleId = it.ScheduleId,
                    CabinTypeId = it.CabinTypeId,
                    Firstname = it.Firstname,
                    Lastname = it.Lastname,
                    Email = it.Email,
                    Phone = it.Phone,
                    PassportNumber = it.PassportNumber,
                    PassportCountryId = it.PassportCountryId,
                    BookingReference = it.BookingReference,
                    Confirmed = it.Confirmed
                }
            );
        }

        return Ok(list);
    }

    private int GetId()
    {
        return Int32.Parse(HttpContext.User.FindFirst("Id")?.Value!);
    }
}
