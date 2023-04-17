using AutoMapper;
using Database.Data.Context;
using Database.Data.Entity;
using Api.Services.Models;
using Microsoft.EntityFrameworkCore;
using Notification;

namespace Api.Services;

public class CommentsService
{
    private readonly MainDbContext _mainDbContext;
    private readonly IMapper _mapper;
    private readonly NotificationService _notificationService;


    public CommentsService(MainDbContext mainDbContext, IMapper mapper, NotificationService notificationService)
    {
        _mapper = mapper;
        _mainDbContext = mainDbContext;
        _notificationService = notificationService;
    }

    public Task<ICollection<GetCommentsModel>> GetAllComments()
    {
        var comment = _mainDbContext
            .Comments
            .Select(l => _mapper.Map<GetCommentsModel>(l))
            .ToList();
        return Task.FromResult<ICollection<GetCommentsModel>>(comment);
    }

    public async Task SaveComment(PostCommentsModel postCommentsModel)
    {
        var result = _mapper.Map<Comments>(postCommentsModel);
        _mainDbContext.Comments.Add(result);
        _mainDbContext.SaveChanges();
        await notifyUser(postCommentsModel);
    }

    private async Task notifyUser(PostCommentsModel postCommentsModel)
    {
        //await _mainDbContext
          //  .Subscriptions
            //.Where(x => x.Problem.Uid == postCommentsModel.ProblemsId)
            //.Select(x => x.User)
            //.ForEachAsync(x => _notificationService.SendNotification(
        // new NotificationDTO(
        //x.Uid,
        //postCommentsModel.ProblemsId,
        // postCommentsModel.Uid,
        //postCommentsModel.UsersId
        // )
        //);
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