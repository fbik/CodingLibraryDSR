using CodingLibraryDSR.Services.Models;
using Services.Models;

namespace CodingLibraryDSR.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("subscriptions")]

public class SubscriptionsController : ControllerBase
{
    private readonly SubscritionsService _subscritionsService;

    public SubscriptionsController(SubscritionsService subscriptionsService)
    {
        _subscritionsService = subscriptionsService;
    }

    [HttpGet(Name = "GetSubscription")]

    public async Task<ICollection<SubscriptionsModel>> Get()
    {
        var result = await _subscritionsService.GetAllSubscriptions();
        return result;
    }

}   