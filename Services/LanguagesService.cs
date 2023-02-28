using CodingLibraryDSR.Services.Models;
using CodingLibraryDSR.Data.Context;
using AutoMapper;

namespace Services.Models;

    public class LanguagesService
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;
        public LanguagesService(MainDbContext mainDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _mainDbContext = mainDbContext;
        }


        public Task<ICollection<LanguagesModel>> GetAllLanguages()
        {
            var languages = _mainDbContext
                .Languages
                .Select(l => _mapper.Map<LanguagesModel>(l))   
                .ToList();
            
            return Task.FromResult<ICollection<LanguagesModel>>(languages);
        }
    }