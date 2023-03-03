using CodingLibraryDSR.Services.Models;
using Services.Models;

namespace CodingLibraryDSR.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet(Name = "GetUsers")]

    public async Task<ICollection<UsersModel>> Get()
    {
        var result = await _usersService.GetAllUsers();
        return result;
    }
}