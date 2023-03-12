using AutoMapper;
using CodingLibraryDSR.Data.Context;
using CodingLibraryDSR.Data.Entity;
using CodingLibraryDSR.Services.Models;

namespace Services.Models;


    public class ProblemsService
    {

        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;

        public ProblemsService(MainDbContext mainDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _mainDbContext = mainDbContext;
        }
        
        public Task<ICollection<ProblemsModel>> GetAllProblems()
        {
            var problems = _mainDbContext
                .Problems
                .Select(l => _mapper.Map<ProblemsModel>(l))
                .ToList();
                
            return Task.FromResult<ICollection<ProblemsModel>>(problems);
        }
    }