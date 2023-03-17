using AutoMapper;
using Api.CodingLibraryDSR.Data.Context;
using Api.CodingLibraryDSR.Services.Models;
using Api.CodingLibraryDSR.Data.Entity;
using Api.Services.Models;

namespace Api.Services;


public class ProblemsService
{

    private readonly MainDbContext _mainDbContext;
    private readonly IMapper _mapper;

    public ProblemsService(MainDbContext mainDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _mainDbContext = mainDbContext;
    }

    public Task<ICollection<GetProblemsModel>> GetAllProblems()
    {
        var problems = _mainDbContext
            .Problems
            .Select(l => _mapper.Map<GetProblemsModel>(l))
            .ToList();

        return Task.FromResult<ICollection<GetProblemsModel>>(problems);
    }

    public void SaveProblems(PostProblemsModel postProblemsModel)
    {
        var result = _mapper.Map<Problems>(postProblemsModel);
        _mainDbContext.Problems.Add(result);
        _mainDbContext.SaveChanges();
    }

    public void UpdateProblems(UpdateProblemsModel updateProblemsModel)
    {
        var result = _mapper.Map<Problems>(updateProblemsModel);
        _mainDbContext.Problems.Update(result);
        _mainDbContext.SaveChanges();
    }
    
    public void DeleteProblem(DeleteProblemsModel deleteProblemsModel)
    {
        var problem = _mainDbContext
            .Problems
            .First(x => x.Uid == deleteProblemsModel.Uid);


        _mainDbContext.Problems.Remove(problem);
        _mainDbContext.SaveChanges();
    }
}