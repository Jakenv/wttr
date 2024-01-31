using Cocona;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using wttr;
using wttr.WttrService;

var builder = CoconaApp.CreateBuilder();

builder.Logging.AddFilter("System.Net.Http", LogLevel.Warning);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IWttrService, WttrService>();

var app = builder.Build();

app.AddCommands<WttrCommands>();

app.Run();