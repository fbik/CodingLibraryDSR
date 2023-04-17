using Duende.IdentityServer.Models;

namespace Identity.Properties.Configuration;

public static class AppResources
{
    public static IEnumerable<ApiResource> Resources => new List<ApiResource>
    {
        new ApiResource("api")
    };
}
