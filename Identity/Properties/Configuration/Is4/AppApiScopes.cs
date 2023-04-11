using Duende.IdentityServer.Models;

namespace Identity.Properties.Configuration;

public static class AppApiScopes
{

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            //new ApiScope(ApiScopes.ProblemsRead, "Access  to problem API - Read data"),
            //new ApiScope(ApiScopes.ProblemsWrite, "Access to problem API - Write data")
        };
}

