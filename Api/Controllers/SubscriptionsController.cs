using Api.CodingLibraryDSR.Services.Models;
using Api.Services;

namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("subscriptions")]

public class SubscriptionsController : ControllerBase
{
    private readonly SubscriptionsService _subscriptionsService;

    public SubscriptionsController(SubscriptionsService subscriptionsService)
    {
        _subscriptionsService = subscriptionsService;
    }

    [HttpGet(Name = "GetSubscription")]

    public async Task<ICollection<SubscriptionsModel>> Get()
    {
        var result = await _subscriptionsService.GetAllSubscriptions();
        return result;
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