using AutoMapper;
using CodingLibraryDSR.Data.Context;
using CodingLibraryDSR.Services.Models;

namespace Services.Models;


    public class CategoriesService
    {

        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;

        public CategoriesService(MainDbContext mainDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _mainDbContext = mainDbContext;
        }
        
        public Task<ICollection<CategoriesModel>> GetAllCategories()
        {
            var categories = _mainDbContext
                .Categories
                .Select(l => _mapper.Map<CategoriesModel>(l))
                .ToList();
            return Task.FromResult<ICollection<CategoriesModel>>(categories);
        }
    }