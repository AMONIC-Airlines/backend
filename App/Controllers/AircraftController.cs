using Microsoft.AspNetCore.Mvc;
using App.Views.Aircraft;
using Domain.UseCases;

namespace App.Controllers;

[ApiController]
[Route("aircraft")]
[Produces("application/json")]
public class AircraftController : ControllerBase
{
    private readonly AircraftService _aircraftService;

    public AircraftController(AircraftService aircraftService)
    {
        _aircraftService = aircraftService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AircraftView>> HandleGet(int id)
    {
        var result = await _aircraftService.GetAircraft(id);

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(
            new AircraftView
            {
                Id = result.Value!.Id,
                Name = result.Value.Name,
                MakeModel = result.Value.MakeModel,
                TotalSeats = result.Value.TotalSeats,
                EconomySeats = result.Value.EconomySeats,
                BusinessSeats = result.Value.BusinessSeats
            }
        );
    }
}
