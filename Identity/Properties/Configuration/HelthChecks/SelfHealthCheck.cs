namespace Identity.Properties.Configuration;

using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

public class SelfHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
    {
        var assembly = Assembly.Load("CodingLibraryDSR.Identity");

        return Task.FromResult(HealthCheckResult.Healthy());
    }
}

