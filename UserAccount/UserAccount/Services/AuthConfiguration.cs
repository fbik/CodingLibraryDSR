using Database;
using Database.Data.Context;
using Database.Data.Entity;
using Identity.Properties.Configuration;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace UserAccount.UserAccount.Services;

public static class AuthConfiguration
{
    public static IServiceCollection AddAppAuth(this IServiceCollection services, IdentitySettings settings)
    {
        IdentityModelEventSource.ShowPII = true;

        services
            .AddIdentity<Users, IdentityRole<Guid>>(opt =>
            {
                opt.Password.RequiredLength = 0;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<MainDbContext>()
            .AddUserManager<UserManager<Users>>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
            {
                //options.RequireHttpsMetadata = settings.Url.StartsWith("https://");
                options.Authority = settings.Url;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                options.Audience = "api";
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(AppScopes.ProblemsRead, policy =>
                policy.RequireClaim("scope", AppScopes.ProblemsRead));
            options.AddPolicy(AppScopes.ProblemsWrite, policy =>
                policy.RequireClaim("scope", AppScopes.ProblemsWrite));
            options.AddPolicy(AppScopes.CategoriesRead, policy =>
                policy.RequireClaim("scope", AppScopes.CategoriesRead));
            options.AddPolicy(AppScopes.CategoriesWrite, policy =>
                policy.RequireClaim("scope", AppScopes.CategoriesWrite));
            options.AddPolicy(AppScopes.LanguagesRead, policy =>
                policy.RequireClaim("scope", AppScopes.LanguagesRead));
            options.AddPolicy(AppScopes.LanguagesWrite, policy =>
                policy.RequireClaim("scope", AppScopes.LanguagesWrite));
            options.AddPolicy(AppScopes.SubscriptionsRead, policy =>
                policy.RequireClaim("scope", AppScopes.SubscriptionsRead));
            options.AddPolicy(AppScopes.SubscriptionsWrite, policy =>
                policy.RequireClaim("scope", AppScopes.SubscriptionsWrite));
            options.AddPolicy(AppScopes.CommentsRead, policy =>
                policy.RequireClaim("scope", AppScopes.CommentsRead));
            options.AddPolicy(AppScopes.CommentsWrite, policy =>
                policy.RequireClaim("scope", AppScopes.CommentsWrite));
        });

        return services;
    }

    public static IApplicationBuilder UseAppAuth(this IApplicationBuilder app)
    {
        app.UseAuthentication();

        app.UseAuthorization();

        return app;
    }
}