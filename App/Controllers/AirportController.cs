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

    [HttpGet("all")]
    public async Task<ActionResult<AirportView>> HandleGetAll()
    {
        var result = await _airportService.GetAllAirports();

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        var list = new List<AirportView>();

        foreach (var it in result.Value!)
        {
            list.Add(
                new AirportView
                {
                    Id = it.Id,
                    CountryId = it.CountryId,
                    Iatacode = it.Iatacode,
                    Name = it.Name
                }
            );
        }

        return Ok(list);
    }
}
