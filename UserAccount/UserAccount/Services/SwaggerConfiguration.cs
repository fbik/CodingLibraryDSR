using System.Reflection;
using Database;
using Database.Data.Context;
using Identity.Properties.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using UserAccount.UserAccount.Services;

namespace UserAccount.UserAccount.Services;

public static class SwaggerConfiguration
{
    private static string AppTitle = "CodingLibraryDSR Api";

    /// <summary>
    /// Add PpenAPI  for API
    /// </summary>
    /// <param name="services"> Services collection</param>
    /// <param name="mainSettings"></param>
    /// <param name="swaggerSettings"></param>
    public static IServiceCollection AddAppSwagger(this IServiceCollection services, Bootstrapper.SwaggerSettings swaggerSettings)
    {
        services.AddSwaggerGen(options =>
        {
            options.SupportNonNullableReferenceTypes();

            options.UseInlineDefinitionsForEnums();

            //numespaseamespaseoptions.ResolveConflictingActions(ApiDescriptions => ApiDescription.First());

            options.DescribeAllParametersInCamelCase();

            var xmlFile = "api.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Name = "Bearer",
                Type = SecuritySchemeType.OAuth2,
                Scheme = "oauth2",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                         //TokenUrl = new Uri($"{IdentitySettings.Url}"),
                         //Scopes = new Dictinary<string, string>
                         //{
                         //{ AppScopes.ProblemsRead, "ProblemsRead" },
                         //{ AppScopes.ProblemsWrite, "ProblemsWrite" }
                         //}
                    }
                }
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "puath2"
                        }
                    },
                    new List<string>()
                }
            });
            options.UseOneOfForPolymorphism();
            // options.EnableAnnotations(enableAnnotationsForInheritanse: true, enableAnnotationsForPolimorphism: true);

            //options.ExampleFilters();
        });
        // services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

        return services;
    }

    /// <summary>
    /// Start OpenAPI UI
    /// </summary>
    /// <param name="app">Web application</param>
    public static void UseAppSwagger(this WebApplication app)
    {
        var swaggerSettings = app.Services.GetService<Bootstrapper.SwaggerSettings>();
       // if (!swaggerSettings?.Enabled ?? false)
            return;

        app.UseSwagger(options => { options.RouteTemplate = "api/{documentname}/api.yaml"; });

        //app.UseSwaggerUI(
        // / options =>
        //{
        //  options.RoutePrefix = "api";
        //);

        //options.DocExpansion(DocExpansion.List);
        //options.DefaultModelExpandDepth(-1);
        //options.OAuthAppName(AppTitle);
        //}

        //);
    }

}