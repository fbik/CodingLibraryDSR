using Api.Services;
using Api.Services.Models;
using Cache;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("problems")]
public class ProblemsController : ControllerBase
{
    private readonly CacheService _cacheService;
    private readonly ProblemsService _problemsService;

    public ProblemsController(ProblemsService problemsService, CacheService cacheService)
    {
        _problemsService = problemsService;
        _cacheService = cacheService;
    }

    [HttpGet("")]
    [Authorize(Policy = AppScopes.ProblemsRead)]
    public async Task<ICollection<GetProblemsModel>> Get()
    {
        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(20));
        var cacheResult = await _cacheService.GetAsync<ICollection<GetProblemsModel>>("Problems");
        if (cacheResult == null)
        {
            var result = await _problemsService.GetAllProblems();
            await _cacheService.SetAsync("Users", result, options);
            return result;
        }

        return cacheResult;
    }
    
    [HttpPost("")]
    [Authorize(Policy = AppScopes.ProblemsWrite)]
    public IActionResult Post([FromBody] PostProblemsModel request)
    {
        _problemsService.SaveProblems(request);
        return Ok("ProblemsPost");
    }
    
    [HttpPut("")]
    [Authorize(Policy = AppScopes.ProblemsWrite)]
    public IActionResult Update([FromBody] UpdateProblemsModel updateProblemsModel)
    {
        _problemsService.UpdateProblems(updateProblemsModel);
        return Ok("ProblemsPut");
    }
    
    [HttpDelete("")]
    [Authorize(Policy = AppScopes.ProblemsWrite)]
    public IActionResult Delete([FromBody] DeleteProblemsModel deleteProblemsModel)
    {
        _problemsService.DeleteProblem(deleteProblemsModel);
        return Ok("ProblemDelete");
    }
}