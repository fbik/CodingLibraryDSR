using Api.CodingLibraryDSR.Services.Models;
using Api.Services;
using Cache;
using Microsoft.Extensions.Caching.Distributed;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("subscriptions")]

public class SubscriptionsController : ControllerBase
{
    private readonly CacheService _cacheService;
    private readonly SubscriptionsService _subscriptionsService;

    public SubscriptionsController(SubscriptionsService subscriptionsService, CacheService cacheService)
    {
        _subscriptionsService = subscriptionsService;
        _cacheService = cacheService;
    }

    [HttpGet("get")]
    
    public async Task<ICollection<GetSubscriptionsModel>> Get()
    {
        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(30));
        var cacheResult = await _cacheService.GetAsync<ICollection<GetSubscriptionsModel>>("Subscriptions");
        if (cacheResult == null)
        {
            var result = await _subscriptionsService.GetAllSubscriptions();
            await _cacheService.SetAsync("Subscriptions", result, options);
            return result;
        }

        return cacheResult;
    }

   
    [HttpPost("add")]

    public IActionResult Post([FromBody] PostSubscriptionsModel request)
    {
        _subscriptionsService.SaveSubscription(request);
        return Ok("SubscriptionPost");
    }
    
    [HttpPut("update")]

    public IActionResult Update([FromBody] UpdateSubscriptionsModel updateSubscriptionsModel)
    {
        _subscriptionsService.UpdateSubscription(updateSubscriptionsModel);
        return Ok("SubscriptionPut");
    }
    
    [HttpDelete("delete")]

    public IActionResult Delete([FromBody] DeleteSubscriptionsModel deleteSubscriptionsModel)
    {
        _subscriptionsService.DeleteSubscription(deleteSubscriptionsModel);
        return Ok("SubscriptionsDelete");
    }

}   