using Microsoft.Extensions.DependencyInjection;
using UserAccount.UserAccount.Services;

namespace UserAccount.UserAccount.Services;

public static class Bootstrapper
{
    public static IServiceCollection AddUserAccountService(this IServiceCollection services)
    {
        services.AddScoped<IUserAccountService, UserAccountService>();

        return services;
    }

    public class SwaggerSettings
    {
    }
}