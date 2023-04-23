using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(configureLogging =>
{
    //configureLogging.ClearProviders();
    configureLogging.AddConfiguration(builder.Configuration.GetSection("Logging"));
    configureLogging.AddConsole();
    configureLogging.AddDebug();
});

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);

builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());

var app = builder.Build();

app.UseOcelot();

app.Run();

