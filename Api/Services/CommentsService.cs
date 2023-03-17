using AutoMapper;
using Api.CodingLibraryDSR.Data.Context;
using Api.CodingLibraryDSR.Data.Entity;
using Api.CodingLibraryDSR.Services.Models;
using Api.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class CommentsService
{

    private readonly MainDbContext _mainDbContext;
    private readonly IMapper _mapper;

    public CommentsService(MainDbContext mainDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _mainDbContext = mainDbContext;
    }
    
    public Task<ICollection<GetCommentsModel>> GetAllComments()
    {
        var comments = _mainDbContext
            .Comments
            .Select(l => _mapper.Map<GetCommentsModel>(l))
            .ToList();
        return Task.FromResult<ICollection<GetCommentsModel>>(comments);
    }
    
    public void SaveComment(PostCommentsModel postCommentsModel)
    {
        var result = _mapper.Map<Comments>(postCommentsModel);
        _mainDbContext.Comments.Add(result);
        _mainDbContext.SaveChanges();
    }
    
    
    public void UpdateComment(UpdateCommentsModel updateCommentsModel)
    {
        var result = _mapper.Map<Comments>(updateCommentsModel);
        _mainDbContext.Comments.Update(result);
        _mainDbContext.SaveChanges();
    }
    
    public void DeleteComment(DeleteCommentsModel deleteCommentsModel)
    {
        var comment = _mainDbContext
            .Comments
            .First(x => x.Uid == deleteCommentsModel.Uid);


        _mainDbContext.Comments.Remove(comment);
        _mainDbContext.SaveChanges();
    }
}