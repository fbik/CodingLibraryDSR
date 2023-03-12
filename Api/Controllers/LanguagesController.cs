using Api.CodingLibraryDSR.Services.Models;
using Api.Services;
using Api.Services.Models;

namespace Api.Controllers;
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

    [HttpPost("add")]

    public IActionResult Post([FromBody] PostLanguagesModel request)
    {
        _languagesService.SaveLanguages(request);
        return Ok("LanguagePost");
    }

    [HttpPut("update")]

    public IActionResult Update([FromBody] UpdateLanguagesModel updateLanguagesModel)
    {
        _languagesService.UpdateLanguage(updateLanguagesModel);
        return Ok("LanguagePut");
    }

    [HttpDelete("delete")]

    public IActionResult Delete([FromBody] DeleteLanguagesModel deleteLanguagesModel)
    {
        _languagesService.DeleteLanguage(deleteLanguagesModel);
        return Ok("LanguageDelete");
    }
    
}