//using Api.CodingLibraryDSR.Data.Context;

using Api.Data.Entity;
using Api.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Identity.Properties.Configuration;

public static class Is4Configuration
{
    static Is4Configuration()
    {
    }

    public static IServiceCollection AddIs4(this IServiceCollection services)
    {
        services
            .AddIdentity<Users, IdentityRole<Guid>>(opt =>
            {
                opt.Password.RequiredLength = 0;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<MainDbContext>()
            .AddUserManager<UserManager<Users>>()
            .AddDefaultTokenProviders()
            ;

        services
            .AddIdentityServer()

            //.AddAspNetIdentity<Users>()

            .AddInMemoryApiScopes(AppApiScopes.ApiScopes)
            .AddInMemoryClients(AppClients.Clients)
            .AddInMemoryApiResources(AppResources.Resources)
            .AddInMemoryIdentityResources(AppIdentityResources.Resources)

            .AddTestUsers(AppApiTestUsers.ApiUsers)

            .AddDeveloperSigningCredential();

        return services;
    }

    public static IApplicationBuilder UseIs4(this IApplicationBuilder app)
    {
       // app.UseIdentityServer();

        return app;
    }
}

