using SvelteApp.Server.Controllers;
using SvelteApp.Server.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var embed = new Microsoft.Extensions.FileProviders.ManifestEmbeddedFileProvider(System.Reflection.Assembly.GetExecutingAssembly(), "wwwroot");
app.UseDefaultFiles(options: new() { FileProvider = embed });
app.UseStaticFiles(options: new() { FileProvider = embed });
app.MapGet("/WeatherForecast", () => WeatherForecastController.Get());
app.Run();

[JsonSerializable(typeof(IEnumerable<WeatherForecast>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
