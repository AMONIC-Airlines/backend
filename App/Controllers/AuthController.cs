using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Views.Auth;
using Database.Models;
using Domain.UseCases;

namespace App.Controllers;

[ApiController]
[Route("authorization")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly UserService _userService;
    private readonly RoleService _roleService;

    public AuthController(
        IConfiguration configuration,
        UserService userService,
        RoleService roleService
    )
    {
        _configuration = configuration;
        _userService = userService;
        _roleService = roleService;
    }

    [HttpGet("login")]
    public async Task<ActionResult<AuthUserView>> HandleLogin([FromQuery] LoginView data)
    {
        var user = await _userService.Authorization(data.Email!, data.Password!);

        if (user.IsException)
        {
            return NotFound();
        }

        if (user.IsFailure)
        {
            return BadRequest(user.Error);
        }

        var role = await _roleService.GetRole(user.Value!.RoleId);

        if (role.IsException)
        {
            return NotFound();
        }

        if (role.IsFailure)
        {
            return BadRequest(role.Error);
        }

        var token = GenerateJwt(user.Value, role.Value!);

        return Ok(
            new AuthUserView
            {
                Id = user.Value.Id,
                Email = user.Value.Email,
                FirstName = user.Value.FirstName,
                LastName = user.Value.LastName,
                Birthdate = user.Value.Birthdate,
                Token = token
            }
        );
    }

    [HttpPost("signup")]
    public async Task<ActionResult> HandleSignup([FromBody] SignupView data)
    {
        var role = await _roleService.GetRoleByTitle("User");

        if (role.IsException)
        {
            return NotFound();
        }

        if (role.IsFailure)
        {
            return BadRequest(role.Error);
        }

        var user = new User
        {
            RoleId = role.Value!.Id,
            Email = data.Email!,
            Password = data.Password!,
            FirstName = data.FirstName,
            LastName = data.LastName!,
            Birthdate = data.Birthdate,
            Active = true
        };

        var result = await _userService.Registration(user);

        if (result.IsException)
        {
            return NotFound();
        }

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok();
    }

    private string GenerateJwt(User user, Role role)
    {
        var claims = new List<Claim>
        {
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email!),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Title!)
        };

        var securityKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!)
        );

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
