using Dapr.Client;
using Dapr.Extensions.Configuration;

var client = new DaprClientBuilder().Build();
var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration(config =>
{
    // Get the initial value and continue to watch it for changes.
    config.AddDaprConfigurationStore("redisconfig", new List<string>() { "withdrawVersion" }, client, TimeSpan.FromSeconds(20));
    config.AddStreamingDaprConfigurationStore("redisconfig", new List<string>() { "withdrawVersion", "source" }, client, TimeSpan.FromSeconds(20));
    //config.AddDaprConfigurationStore("azappconfig", new List<string>() { "withdrawVersion" }, client, TimeSpan.FromSeconds(20));
    //config.AddStreamingDaprConfigurationStore("azappconfig", new List<string>() { "withdrawVersion", "source" }, client, TimeSpan.FromSeconds(20));

});

builder.Services.AddControllers().AddDapr();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Hello World!");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
