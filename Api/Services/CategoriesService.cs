using AutoMapper;
using Api.CodingLibraryDSR.Data.Context;
using Api.CodingLibraryDSR.Services.Models;
using Api.CodingLibraryDSR.Data.Entity;
using Api.Services.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Api.Services;


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
        
        public void SaveCategory(PostCategoriesModel postCategoriesModel)
        {
            var result = _mapper.Map<Categories>(postCategoriesModel);
            _mainDbContext.Categories.Add(result);
            _mainDbContext.SaveChanges();
        }
        
        public void UpdateCategory(UpdateCategoriesModel updateCategoriesModel)
        {
            var result = _mapper.Map<Categories>(updateCategoriesModel);
            _mainDbContext.Categories.Update(result);
            _mainDbContext.SaveChanges();
        }
        
        public void DeleteCategory(DeleteCategoriesModel deleteCategoriesModel)
        {
            var category = _mainDbContext
                .Categories
                .First(x => x.Uid == deleteCategoriesModel.Uid);


            _mainDbContext.Categories.Remove(category);
            _mainDbContext.SaveChanges();
        }
    }