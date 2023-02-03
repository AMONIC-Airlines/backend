using Microsoft.AspNetCore.Mvc;
using App.Views.Airport;
using Domain.UseCases;

namespace App.Controllers;

[ApiController]
[Route("airport")]
[Produces("application/json")]
public class AirportController : ControllerBase
{
    private readonly AirportService _airportService;

    public AirportController(AirportService airportService)
    {
        _airportService = airportService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AirportView>> HandleGet(int id)
    {
        var result = await _airportService.GetAirport(id);

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(
            new AirportView
            {
                Id = result.Value!.Id,
                CountryId = result.Value.CountryId,
                Iatacode = result.Value.Iatacode,
                Name = result.Value.Name
            }
        );
    }
}
