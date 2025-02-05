using SvelteApp.Server.Controllers;
using SvelteApp.Server.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();


app.UseDefaultFiles();
app.UseStaticFiles();
app.MapGet("/WeatherForecast", () => WeatherForecastController.Get());
app.Run();

[JsonSerializable(typeof(IEnumerable<WeatherForecast>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
