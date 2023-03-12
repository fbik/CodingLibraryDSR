using Api.CodingLibraryDSR.Services.Models;
using Api.Services;
using Api.Services.Models;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("problems")]
public class ProblemsController : ControllerBase
{

    private readonly ProblemsService _problemsService;

    public ProblemsController(ProblemsService problemsService)
    {
        _problemsService = problemsService;
    }

    [HttpGet(Name = "GetProblems")]

    public async Task<ICollection<ProblemsModel>> Get()
    {
        var result = await _problemsService.GetAllProblems();
        return result;
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