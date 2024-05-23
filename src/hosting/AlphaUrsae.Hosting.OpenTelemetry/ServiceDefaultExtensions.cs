using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using OpenTelemetry;

namespace AlphaUrsae.Hosting.OpenTelemetry;

public static class ServiceDefaultExtensions
{
    public static IHostApplicationBuilder AddOpenTelemetry(
        this IHostApplicationBuilder builder
        , Action<MeterProviderBuilder> metricsBuild
        , Action<TracerProviderBuilder> tracingBuild)
    {
        builder.Logging.AddOpenTelemetry(logging =>
        {
            logging.IncludeFormattedMessage = true;
            logging.IncludeScopes = true;
        });

        builder.Services.AddOpenTelemetry()
           .WithMetrics(metrics =>
           {
               metrics
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation();
               metricsBuild(metrics);
           })
           .WithTracing(tracing =>
           {
               tracing
                   // Uncomment the following line to enable gRPC instrumentation (requires the OpenTelemetry.Instrumentation.GrpcNetClient package)
                   //.AddGrpcClientInstrumentation()
                   .AddHttpClientInstrumentation();
               tracingBuild(tracing);
           });

        builder.AddOpenTelemetryExporters();

        return builder;
    }
    public static IHostApplicationBuilder AddOpenTelemetry(this IHostApplicationBuilder builder)
    {
        builder.AddOpenTelemetry((_) => { }, (_) => { });;
        return builder;
    }

    private static IHostApplicationBuilder AddOpenTelemetryExporters(this IHostApplicationBuilder builder)
    {
        var useOtlpExporter = !string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);

        if (useOtlpExporter)
        {
            builder.Services.AddOpenTelemetry().UseOtlpExporter();
        }

        // Uncomment the following lines to enable the Prometheus exporter (requires the OpenTelemetry.Exporter.Prometheus.AspNetCore package)
        // builder.Services.AddOpenTelemetry()
        //    .WithMetrics(metrics => metrics.AddPrometheusExporter());

        // Uncomment the following lines to enable the Azure Monitor exporter (requires the Azure.Monitor.OpenTelemetry.AspNetCore package)
        //if (!string.IsNullOrEmpty(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]))
        //{
        //    builder.Services.AddOpenTelemetry()
        //       .UseAzureMonitor();
        //}

        return builder;
    }
}
