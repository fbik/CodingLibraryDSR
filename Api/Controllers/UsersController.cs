using Api.CodingLibraryDSR.Services.Models;
using Api.Services.Models;
using Api.Services;

namespace Api.Controllers;
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
    
    [HttpPost("add")]

    public IActionResult Post([FromBody] PostUsersModel request)
    {
        _usersService.SaveUsers(request);
        return Ok("UsersPost");
    }
    
    [HttpPut("update")]

    public IActionResult Update([FromBody] UpdateUsersModel updateUsersModel)
    {
        _usersService.UpdateUser(updateUsersModel);
        return Ok("UsersPut");
    }
    
    [HttpDelete("delete")]

    public IActionResult Delete([FromBody] DeleteUsersModel deleteUsersModel)
    {
        _usersService.DeleteUser(deleteUsersModel);
        return Ok("UserDelete");
    }
}