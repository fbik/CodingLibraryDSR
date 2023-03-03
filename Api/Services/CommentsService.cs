using AutoMapper;
using CodingLibraryDSR.Data.Context;
using CodingLibraryDSR.Services.Models;

namespace Services.Models;

public class CommentsService
{

    private readonly MainDbContext _mainDbContext;
    private readonly IMapper _mapper;

    public CommentsService(MainDbContext mainDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _mainDbContext = mainDbContext;
    }
    
    public Task<ICollection<CommentsModel>> GetAllComments()
    {
        var comments = _mainDbContext
            .Comments
            .Select(l => _mapper.Map<CommentsModel>(l))
            .ToList();
        return Task.FromResult<ICollection<CommentsModel>>(comments);
    }
}