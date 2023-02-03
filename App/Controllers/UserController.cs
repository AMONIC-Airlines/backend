using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using App.Views.User;
using Domain.UseCases;

namespace App.Controllers;

[ApiController]
[Route("user")]
[Produces("application/json")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<UserView>> HandleGetUser()
    {
        var result = await _userService.GetUser(GetId());

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(
            new UserView
            {
                Id = result.Value!.Id,
                Email = result.Value.Email,
                FirstName = result.Value.FirstName,
                LastName = result.Value.LastName,
                Birthdate = result.Value.Birthdate
            }
        );
    }

    [HttpPost]
    public async Task<ActionResult<UserView>> HandleUpdateUser([FromBody] UpdateView data)
    {
        var user = await _userService.GetUser(GetId());

        if (user.IsException)
        {
            return NotFound();
        }

        if (user.IsFailure)
        {
            return BadRequest(user.Error);
        }

        user.Value!.FirstName = data.FirstName;
        user.Value.LastName = data.LastName!;
        user.Value.Birthdate = data.Birthdate;

        var result = await _userService.UpdateUser(user.Value);

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(user.Error);
        }

        return Ok(
            new UserView
            {
                Id = result.Value!.Id,
                Email = result.Value.Email,
                FirstName = result.Value.FirstName,
                LastName = result.Value.LastName,
                Birthdate = result.Value.Birthdate
            }
        );
    }

    private int GetId()
    {
        return Int32.Parse(HttpContext.User.FindFirst("Id")?.Value!);
    }
}
