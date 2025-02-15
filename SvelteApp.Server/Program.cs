using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using SvelteApp.Server.Controllers;
using SvelteApp.Server.Models;
using System.Text.Json.Serialization;
using static SvelteApp.Server.WebUI;

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
var run = app.RunAsync($"http://[::1]:0");
var addr = app.Services.GetRequiredService<IServer>().Features.GetRequiredFeature<IServerAddressesFeature>().Addresses.Single();
var port = webui_get_free_port();
app.MapGet("/webui.js", () => Results.Redirect($"http://localhost:{port}/webui.js"));
await Task.WhenAny(run, Task.Run(() =>
{
    var win = webui_new_window();
    _ = webui_set_port(win, port) ? true : throw new("webui_set_port : fail");
    _ = webui_show(win, addr.Replace("[::1]", "localhost")) ? true : throw new("webui_show fail");
    webui_wait();
}));

[JsonSerializable(typeof(IEnumerable<WeatherForecast>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
