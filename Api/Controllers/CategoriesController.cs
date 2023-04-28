using Api.Services;
using Api.Services.ApiServices;
using Api.Services.Models;
using Cache;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
//[Authorize]
[Route("categories")]
public class CategoriesController : ControllerBase
{
    private readonly CacheService _cacheService;
    private readonly CategoriesService _categoriesService;

    public CategoriesController(CategoriesService categoriesService, CacheService cacheService)
    {
        _categoriesService = categoriesService;
        _cacheService = cacheService;
    }

    [HttpGet("get")]
    //[Authorize(Policy = AppScopes.CategoriesRead)]
    public async Task<ICollection<GetCategoriesModel>> Get()
    {
        var cacheResult = await _cacheService.GetAsync<ICollection<GetCategoriesModel>>("Categories");
        if (cacheResult == null)
        {
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(30));
            var result = await _categoriesService.GetAllCategories();
            await _cacheService.SetAsync("Categories", result, options);
            return result;
        }

        return cacheResult;
    }
    
    [HttpPost("add")]
    //[Authorize(Policy = AppScopes.CategoriesWrite)]
    public IActionResult Post([FromBody] PostCategoriesModel request)
    {
        _categoriesService.SaveCategories(request);
        return Ok("CategoriesPost");
    }
    
    [HttpPut("put")]
    //[Authorize(Policy = AppScopes.CategoriesWrite)]
    public IActionResult Update([FromBody] UpdateCategoriesModel updateCategoriesModel)
    {
        _categoriesService.UpdateCategories(updateCategoriesModel);
        return Ok("CategoryPut");
    }
    
    [HttpDelete("delete")]
    //[Authorize(Policy = AppScopes.CategoriesWrite)]
    public IActionResult Delete([FromBody] DeleteCategoriesModel deleteCategoriesModel)
    {
        _categoriesService.DeleteCategories(deleteCategoriesModel);
        return Ok("CategoryDelete");
    }
}