namespace Identity.Properties.Configuration;

public static class Bootstrapper
{
    public static IServiceCollection AddMainSettings(this IServiceCollection services,
        IConfiguration configuration = null)
    {
        var settings = Settings.Load<MainSettings>("Main", configuration);
        services.AddSingleton(settings);

        return services;
    }
    
    public static IServiceCollection AddIdentitySettings(this IServiceCollection services,
        IConfiguration configuration = null)
    {
        var settings = Settings.Load<IdentitySettings>("Identity", configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddSwaggerSetting(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = Settings.Load<SwaggerSettings>("Swagger", configuration);
        services.AddSingleton(settings);

        return services;
    }

    public class SwaggerSettings
    {
        private const bool Enabled = true;
    }
}

