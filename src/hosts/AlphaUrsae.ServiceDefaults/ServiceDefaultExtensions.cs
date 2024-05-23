using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AlphaUrsae.ServiceDefaults;

public static class ServiceDefaultExtensions
{
    public static IHostApplicationBuilder AddServiceDefaults(
        this IHostApplicationBuilder builder) 
    {
        builder.Services.ConfigureHttpClientDefaults(http =>
        {
            // Turn on resilience by default
            http.AddStandardResilienceHandler();
        });

        return builder;
    }
}
