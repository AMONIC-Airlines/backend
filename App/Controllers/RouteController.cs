using Microsoft.AspNetCore.Mvc;
using App.Views.Route;
using Domain.UseCases;

namespace App.Controllers;

[ApiController]
[Route("route")]
[Produces("application/json")]
public class RouteController : ControllerBase
{
    private readonly RouteService _routeService;

    public RouteController(RouteService routeService)
    {
        _routeService = routeService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RouteView>> HandleGet(int id)
    {
        var result = await _routeService.GetRoute(id);

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(
            new RouteView
            {
                Id = result.Value!.Id,
                DepartureAirportId = result.Value.DepartureAirportId,
                ArrivalAirportId = result.Value.ArrivalAirportId,
                Distance = result.Value.Distance,
                FlightTime = result.Value.FlightTime
            }
        );
    }
}
