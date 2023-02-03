using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using App.Views.Auth;
using Database.Models;
using Domain.UseCases;

namespace App.Controllers;

[ApiController]
[Route("admin")]
[Produces("application/json")]
[Authorize(Roles = "Administrator")]
public class AdminController
{
    private readonly UserController _userController;

    public AdminController(UserController userController)
    {
        _userController = userController;
    }
}
