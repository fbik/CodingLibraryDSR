using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web;
using Web.Pages.Problems.Service;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp =>
{
    var client = new HttpClient();
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    return client;
});

builder.Services.AddScoped<ProblemsService>();

await builder.Build().RunAsync();