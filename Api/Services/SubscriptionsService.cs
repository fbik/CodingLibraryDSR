using AutoMapper;
using Api.Data.Context;
using Api.Data.Entity;
using Api.CodingLibraryDSR.Services.Models;

namespace Api.Services;

public class SubscriptionsService
{
    private readonly MainDbContext _mainDbContext;
    private readonly IMapper _mapper;

    public SubscriptionsService(MainDbContext mainDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _mainDbContext = mainDbContext;
    }
    
    public Task<ICollection<GetSubscriptionsModel>> GetAllSubscriptions()
    {
        var subscriptions = _mainDbContext
            .Subscriptions
            .Select(l => _mapper.Map<GetSubscriptionsModel>(l))
            .ToList();
        return Task.FromResult<ICollection<GetSubscriptionsModel>>(subscriptions);
    }
    
    public void SaveSubscription(PostSubscriptionsModel postSubscriptionsModel)
    {
        var result = _mapper.Map<Subscriptions>(postSubscriptionsModel);
        _mainDbContext.Subscriptions.Add(result);
        _mainDbContext.SaveChanges();
    }
    
    public void UpdateSubscription(UpdateSubscriptionsModel updateSubscriptionsModel)
    {
        var result = _mapper.Map<Subscriptions>(updateSubscriptionsModel);
        _mainDbContext.Subscriptions.Update(result);
        _mainDbContext.SaveChanges();
    }
    
    public void DeleteSubscription(DeleteSubscriptionsModel deleteSubscriptionsModel)
    {
        var subscription = _mainDbContext
            .Subscriptions
            .First(x => x.Uid == deleteSubscriptionsModel.Uid);


        _mainDbContext.Subscriptions.Remove(subscription);
        _mainDbContext.SaveChanges();
    }
}
