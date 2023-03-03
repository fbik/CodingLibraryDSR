
using CodingLibraryDSR.Services.Models;
using Services.Models;

namespace CodingLibraryDSR.Controllers;
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
}