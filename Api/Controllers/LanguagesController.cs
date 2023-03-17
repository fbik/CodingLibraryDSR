using Api.CodingLibraryDSR.Services.Models;
using Api.Services;
using Api.Services.Models;
using Cache;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("languages")]
public class LanguagesController : ControllerBase
{
    private readonly CacheService _cacheService;
    private readonly LanguagesService _languagesService;

    public LanguagesController(LanguagesService languagesService, CacheService cacheService)
    {
        _languagesService = languagesService;
        _cacheService = cacheService;

    }

    [HttpGet("get")]

    public async Task<ICollection<GetLanguagesModel>> Get()
    {
        var cacheResult = await _cacheService.GetAsync<ICollection<GetLanguagesModel>>("languages");
        if (cacheResult == null)
        {
            var result = await _languagesService.GetAllLanguages();
            await _cacheService.SetAsync("languages", result);
            return result;
        }

        return cacheResult;
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