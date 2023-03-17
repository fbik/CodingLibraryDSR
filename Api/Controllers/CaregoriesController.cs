using Api.CodingLibraryDSR.Services.Models;
using Api.Services;
using Api.Services.Models;
using Cache;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
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

    public async Task<ICollection<GetCategoriesModel>> Get()
    {
        var cacheResult = await _cacheService.GetAsync<ICollection<GetCategoriesModel>>("Categories");
        if (cacheResult == null)
        {
            var result = await _categoriesService.GetAllCategories();
            await _cacheService.SetAsync("Categories", result);
            return result;
        }

        return cacheResult;
    }
    
    [HttpPost("add")]

    public IActionResult Post([FromBody] PostCategoriesModel request)
    {
        _categoriesService.SaveCategory(request);
        return Ok("CategoriesPost");
    }
    
    [HttpPut("put")]
    public IActionResult Update([FromBody] UpdateCategoriesModel updateCategoriesModel)
    {
        _categoriesService.UpdateCategory(updateCategoriesModel);
        return Ok("CategoryPut");
    }
    
    [HttpDelete("delete")]

    public IActionResult Delete([FromBody] DeleteCategoriesModel deleteCategoriesModel)
    {
        _categoriesService.DeleteCategory(deleteCategoriesModel);
        return Ok("CategoryDelete");
    }
}