using CodingLibraryDSR.Services.Models;

namespace Services.Models;


public class SubscritionsService
    {
        public Task<ICollection<SubscriptionsModel>> GetAllSubscriptions()
        {
            return Task.FromResult<ICollection<SubscriptionsModel>>(new List<SubscriptionsModel>());
        }
    }
