using Microsoft.Extensions.Hosting;
using AlphaUrsae.Hosting.OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace AlphaUrsae.Hosting.OpenTelemetry.AspNetCore;

public static class ServiceDefaultExtensions
{
    public static IHostApplicationBuilder AddOpenTelemetryAspNetCore(this IHostApplicationBuilder builder)
    {
        builder.AddOpenTelemetry(
            (m) => m.AddAspNetCoreInstrumentation()
            , (m) => m.AddAspNetCoreInstrumentation());

        return builder;
    }
}

