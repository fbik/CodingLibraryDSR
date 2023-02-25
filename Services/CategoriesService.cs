using CodingLibraryDSR.Services.Models;

namespace Services.Models;


    public class CategoriesService
    {
        public Task<ICollection<CategoriesModel>> GetAllCategories()
        {
            return Task.FromResult<ICollection<CategoriesModel>>(new List<CategoriesModel>());
        }
    }