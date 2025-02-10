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
var win = webui_new_window();
// todo: webui_show(win, addr);
_ = webui_show(win, $$"""
<html>
    <script src="webui.js"></script>
    <style>
        html, body, iframe {
            margin: 0;
            padding: 0;
            width: 100%;
            height: 100%;
            border: none;
            position: absolute;
        }
    </style>
    <iframe src="{{addr}}"></iframe>
</html>
""") ? true : throw new("webui_show fail");
await Task.WhenAny(run, Task.Run(webui_wait));

[JsonSerializable(typeof(IEnumerable<WeatherForecast>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
