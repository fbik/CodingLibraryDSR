using CodingLibraryDSR.Services.Models;

namespace Services.Models;

    public class LanguagesService
    {
        public Task<ICollection<LanguagesModel>> GetAllLanguages()
        {
            return Task.FromResult<ICollection<LanguagesModel>>(new List<LanguagesModel>());
        }
    }