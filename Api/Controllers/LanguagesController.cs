using Api.Services;
using Api.Services.Models;
using Cache;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController] 
//[Authorize]
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
    //[Authorize(Policy = AppScopes.LanguagesRead)]
    public async Task<ICollection<GetLanguagesModel>> Get()
    {
        var cacheResult = await _cacheService.GetAsync<ICollection<GetLanguagesModel>>("languages");
        if (cacheResult == null)
        {
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(30));
            var result = await _languagesService.GetAllLanguages();
            await _cacheService.SetAsync("languages", result, options);
            return result;
        }

        return cacheResult;
    }
    
    [HttpPost("add")]
    //[Authorize(Policy = AppScopes.LanguagesWrite)]
    public IActionResult Post([FromBody] PostLanguagesModel request)
    {
        _languagesService.SaveLanguages(request);
        return Ok("LanguagePost");
    }

    [HttpPut("update")]
    [Authorize(Policy = AppScopes.LanguagesWrite)]
    public IActionResult Update([FromBody] UpdateLanguagesModel updateLanguagesModel)
    {
        _languagesService.UpdateLanguage(updateLanguagesModel);
        return Ok("LanguagePut");
    }

    [HttpDelete("delete")]
    [Authorize(Policy = AppScopes.LanguagesWrite)]
    public IActionResult Delete([FromBody] DeleteLanguagesModel deleteLanguagesModel)
    {
        _languagesService.DeleteLanguage(deleteLanguagesModel);
        return Ok("LanguageDelete");
    }
    
}