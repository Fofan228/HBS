using HBS.Data;
using HBS.Core;
using HBS.Service;
using HBS.Service.Configuration;

var host = Host.CreateDefaultBuilder(args);

host.ConfigureAppConfiguration((context, configuration) =>
{
    AppConfigurationConfig.Configure(configuration, context.HostingEnvironment);
});

host.ConfigureServices((context, services) =>
{
    services.AddCore();
    services.AddData();
    services.AddHostedService<Worker>();
});

var app = host.Build();

app.Run();
