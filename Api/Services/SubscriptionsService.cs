using AutoMapper;
using Api.CodingLibraryDSR.Data.Context;
using Api.CodingLibraryDSR.Data.Entity;
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
    
    public Task<ICollection<SubscriptionsModel>> GetAllSubscriptions()
    {
        var subscriptions = _mainDbContext
            .Subscriptions
            .Select(l => _mapper.Map<SubscriptionsModel>(l))
            .ToList();
        return Task.FromResult<ICollection<SubscriptionsModel>>(subscriptions);
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
