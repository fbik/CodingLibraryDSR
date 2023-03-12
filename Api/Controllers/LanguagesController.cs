using CodingLibraryDSR.Services.Models;
using Services.Models;

namespace CodingLibraryDSR.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("languages")]
public class LanguagesController : ControllerBase
{
    private readonly LanguagesService _languagesService;

    public LanguagesController(LanguagesService languagesService)
    {
        _languagesService = languagesService;
    }

    [HttpGet (Name = "GetLanguages")]

    public async Task<ICollection<LanguagesModel>> Get()
    {
        var result = await _languagesService.GetAllLanguages();
        return result;
    }
}