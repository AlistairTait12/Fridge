using FridgeConsole;
using FridgeConsole.DataAccess;
using FridgeConsole.Models;
using FridgeConsole.Presentation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<FridgeService>();
builder.Services.AddTransient<IDataAccess<CharacterInventoryModel>, JsonDataAccess<CharacterInventoryModel>>();
builder.Services.AddTransient<IFridgeMessageViewModelBuilder, FridgeMessageViewModelBuilder>();
builder.Services.AddTransient<IFridgeMessageModelPrinter, FridgeMessageModelPrinter>();
builder.Services.AddTransient<IConsoleWrapper, ConsoleWrapper>();
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json");
builder.Services.Configure<DataAccessOptions>(builder.Configuration.GetSection("DataAccess"));

using IHost host = builder.Build();

await host.RunAsync();