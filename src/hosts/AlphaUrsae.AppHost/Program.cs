using AlphaUrsae.AppHost;
using AlphaUrsae.Hosting.OpenTelemetry;
using AlphaUrsae.ServiceDefaults;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.AddOpenTelemetry();
builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

IHost host = builder.Build();
await host.RunAsync();