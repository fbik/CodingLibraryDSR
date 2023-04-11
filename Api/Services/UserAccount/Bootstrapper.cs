using Microsoft.Extensions.DependencyInjection;
using UserAccount.Services;

namespace UserAccount.Services;

public static class Bootstrapper
{
    public static IServiceCollection AddUserAccountService(this IServiceCollection services)
    {
        services.AddScoped<IUserAccountService, UserAccountService>();

        return services;
    }
}