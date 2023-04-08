using Duende.IdentityServer.Models;

namespace Identity.Properties.Configuration;

public static class AppIdentityResources
{
    public static IEnumerable<IdentityResource> Resources => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
    };
}

