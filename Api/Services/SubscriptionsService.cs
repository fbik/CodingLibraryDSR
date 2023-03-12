using AutoMapper;
using CodingLibraryDSR.Data.Context;
using CodingLibraryDSR.Services.Models;

namespace Services.Models;

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
}
