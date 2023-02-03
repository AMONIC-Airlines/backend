using Microsoft.AspNetCore.Mvc;
using App.Views.Country;
using Domain.UseCases;

namespace App.Controllers;

[ApiController]
[Route("country")]
[Produces("application/json")]
public class CountryController : ControllerBase
{
    private readonly CountryService _countryService;

    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CountryView>> HandleGet(int id)
    {
        var result = await _countryService.GetCountry(id);

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(new CountryView { Id = result.Value!.Id, Name = result.Value.Name });
    }

    [HttpGet("all")]
    public async Task<ActionResult<CountryView>> HandleGetAll()
    {
        var result = await _countryService.GetAllCountries();

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        var list = new List<CountryView>();

        foreach (var it in result.Value!)
        {
            list.Add(new CountryView { Id = it.Id, Name = it.Name });
        }

        return Ok(list);
    }
}
