using Microsoft.AspNetCore.Mvc;
using App.Views.Cabintype;
using Domain.UseCases;

namespace App.Controllers;

[ApiController]
[Route("cabintype")]
[Produces("application/json")]
public class CabintypeController : ControllerBase
{
    private readonly CabintypeService _cabintypeService;

    public CabintypeController(CabintypeService cabintypeService)
    {
        _cabintypeService = cabintypeService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CabintypeView>> HandleGet(int id)
    {
        var result = await _cabintypeService.GetCabintype(id);

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest();
        }

        return Ok(new CabintypeView { Id = result.Value!.Id, Name = result.Value!.Name });
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<CabintypeView>>> HandleGetAll()
    {
        var result = await _cabintypeService.GetAllCabintypes();

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        var list = new List<CabintypeView>();

        foreach (var it in result.Value!)
        {
            list.Add(new CabintypeView { Id = it.Id, Name = it.Name });
        }

        return Ok(list);
    }
}
