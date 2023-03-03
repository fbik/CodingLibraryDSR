using CodingLibraryDSR.Services.Models;
using Services.Models;

namespace CodingLibraryDSR.Controllers;
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
}