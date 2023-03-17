using Api.CodingLibraryDSR.Services.Models;
using Api.Services.Models;
using Api.Services;
using Cache;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly CacheService _cacheService;
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService, CacheService cacheService)
    {
        _usersService = usersService;
        _cacheService = cacheService;
    }

    [HttpGet("get")]
    
    public async Task<ICollection<GetUsersModel>> Get()
    {
        var cacheResult = await _cacheService.GetAsync<ICollection<GetUsersModel>>("Users");
        if (cacheResult == null)
        {
            var result = await _usersService.GetAllUsers();
            await _cacheService.SetAsync("Users", result);
            return result;
        }

        return cacheResult;
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