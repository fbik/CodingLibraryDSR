using Api.CodingLibraryDSR.Services.Models;
using Api.Data.Context;
using Api.Data.Entity;
using Api.Services.Models;
using AutoMapper;

namespace Api.Services;

    public class LanguagesService
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;
        public LanguagesService(MainDbContext mainDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _mainDbContext = mainDbContext;
        }


        public Task<ICollection<GetLanguagesModel>> GetAllLanguages()
        {
            var languages = _mainDbContext
                .Languages
                .Select(l => _mapper.Map<GetLanguagesModel>(l))   
                .ToList();
            
            return Task.FromResult<ICollection<GetLanguagesModel>>(languages);
        }

        public void SaveLanguages(PostLanguagesModel postLanguagesModel)
        {
            var result = _mapper.Map<Languages>(postLanguagesModel);
            _mainDbContext.Languages.Add(result);
            _mainDbContext.SaveChanges();
        }

        public void UpdateLanguage(UpdateLanguagesModel updateLanguagesModel)
        {
            var result = _mapper.Map<Languages>(updateLanguagesModel);
            _mainDbContext.Languages.Update(result);
            _mainDbContext.SaveChanges();
        }

        public void DeleteLanguage(DeleteLanguagesModel deleteLanguagesModel)
        {
            var language = _mainDbContext
                .Languages
                .First(x => x.Uid == deleteLanguagesModel.Uid);


            _mainDbContext.Languages.Remove(language);
            _mainDbContext.SaveChanges();
        }
    }