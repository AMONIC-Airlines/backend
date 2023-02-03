using Microsoft.AspNetCore.Mvc;
using App.Views.Schedule;
using Domain.UseCases;

namespace App.Controllers;

[ApiController]
[Route("schedule")]
[Produces("application/json")]
public class ScheduleController : ControllerBase
{
    private readonly ScheduleService _scheduleService;
    private readonly RouteService _routeService;

    public ScheduleController(ScheduleService scheduleService, RouteService routeService)
    {
        _scheduleService = scheduleService;
        _routeService = routeService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<ScheduleView>>> HandleGetAllSchedules()
    {
        var result = await _scheduleService.GetAllSchedules();

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        var list = new List<ScheduleView>();

        foreach (var it in result.Value!)
        {
            list.Add(
                new ScheduleView
                {
                    Id = it.Id,
                    Date = it.Date,
                    Time = it.Time,
                    AircraftId = it.AircraftId,
                    RouteId = it.RouteId,
                    EconomyPrice = it.EconomyPrice,
                    Confirmed = it.Confirmed,
                    FlightNumber = it.FlightNumber
                }
            );
        }

        return Ok(list);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<ScheduleView>>> HandleSearch([FromQuery] SearchView data)
    {
        var byAirports = await _routeService.GetByDepartureAndArrivalAirportId(
            data.DepartureId,
            data.ArrivalId
        );

        if (byAirports.IsException)
        {
            return NotFound();
        }

        if (byAirports.IsFailure)
        {
            return BadRequest(byAirports.Error);
        }

        var byDate = await _scheduleService.GetByDate(data.Date);

        if (byDate.IsException)
        {
            return NotFound();
        }

        if (byDate.IsFailure)
        {
            return BadRequest(byDate.Error);
        }

        var list = new List<ScheduleView>();

        foreach (var schedule in byDate.Value!)
        {
            foreach (var route in byAirports.Value!)
            {
                if (schedule.RouteId == route.Id)
                {
                    continue;
                }

                list.Add(
                    new ScheduleView
                    {
                        Id = schedule.Id,
                        Date = schedule.Date,
                        Time = schedule.Time,
                        AircraftId = schedule.AircraftId,
                        RouteId = schedule.RouteId,
                        EconomyPrice = schedule.EconomyPrice,
                        Confirmed = schedule.Confirmed,
                        FlightNumber = schedule.FlightNumber
                    }
                );
            }
        }

        return Ok(list);
    }
}
