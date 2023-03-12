using Api.CodingLibraryDSR.Services.Models;
using Api.Services;
using Api.Services.Models;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("categories")]
public class CategoriesController : ControllerBase
{
    private readonly CategoriesService _categoriesService;

    public CategoriesController(CategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    [HttpGet(Name = "GetCategories")]

    public async Task<ICollection<CategoriesModel>> Get()
    {
        var result = await _categoriesService.GetAllCategories();
        return result;
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