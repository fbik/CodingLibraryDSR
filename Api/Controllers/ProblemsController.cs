using Api.CodingLibraryDSR.Services.Models;
using Api.Services;
using Api.Services.Models;
using Cache;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
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

    [HttpGet("get")]
    
    public async Task<ICollection<GetProblemsModel>> Get()
    {
        var cacheResult = await _cacheService.GetAsync<ICollection<GetProblemsModel>>("Problems");
        if (cacheResult == null)
        {
            var result = await _problemsService.GetAllProblems();
            await _cacheService.SetAsync("Users", result);
            return result;
        }

        return cacheResult;
    }
    

    [HttpPost("add")]

    public IActionResult Post([FromBody] PostProblemsModel request)
    {
        _problemsService.SaveProblems(request);
        return Ok("ProblemsPost");
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateProblemsModel updateProblemsModel)
    {
        _problemsService.UpdateProblems(updateProblemsModel);
        return Ok("ProblemsPut");
    }
    
    [HttpDelete("delete")]
    public IActionResult Delete([FromBody] DeleteProblemsModel deleteProblemsModel)
    {
        _problemsService.DeleteProblem(deleteProblemsModel);
        return Ok("ProblemDelete");
    }
}