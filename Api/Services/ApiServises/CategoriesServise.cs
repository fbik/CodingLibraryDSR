using Api.Services.Models;
using AutoMapper;
using Database.Data.Context;
using Database.Data.Entity;

namespace Api.Services.ApiServices;

public class CategoriesService
{
    private readonly MainDbContext _mainDbContext;
    private readonly IMapper _mapper;
    public CategoriesService(MainDbContext mainDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _mainDbContext = mainDbContext;
    }


    public Task<ICollection<GetCategoriesModel>> GetAllCategories()
    {
        var categories = _mainDbContext
            .Categories
            .Select(l => _mapper.Map<GetCategoriesModel>(l))   
            .ToList();
            
        return Task.FromResult<ICollection<GetCategoriesModel>>(categories);
    }

    public void SaveCategories(PostCategoriesModel postCategoriesModel)
    {
        var result = _mapper.Map<Categories>(postCategoriesModel);
        _mainDbContext.Categories.Add(result);
        _mainDbContext.SaveChanges();
    }

    public void UpdateCategories(UpdateCategoriesModel updateCategoriesModel)
    {
        var result = _mapper.Map<Categories>(updateCategoriesModel);
        _mainDbContext.Categories.Update(result);
        _mainDbContext.SaveChanges();
    }

    public void DeleteCategories(DeleteCategoriesModel deleteCategoriesModel)
    {
        var categories = _mainDbContext
            .Categories
            .First(predicate: x => x.Uid == deleteCategoriesModel.Uid);


        _mainDbContext.Categories.Remove(categories);
        _mainDbContext.SaveChanges();
    }
}