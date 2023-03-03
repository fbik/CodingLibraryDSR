using CodingLibraryDSR.Services.Models;
using Services.Models;

namespace CodingLibraryDSR.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("subscriptions")]

public class SubscriptionsController : ControllerBase
{
    private readonly SubscriptionsService _subscritionsService;

    public SubscriptionsController(SubscriptionsService subscriptionsService)
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