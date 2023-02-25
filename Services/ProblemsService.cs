using CodingLibraryDSR.Services.Models;

namespace Services.Models;


    public class ProblemsService
    {
        public Task<ICollection<ProblemsModel>> GetAllProblems()
        {
            return Task.FromResult<ICollection<ProblemsModel>>(new List<ProblemsModel>());
        }
    }