using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyHostWithDIConfigurationLoggingWorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Environment.ContentRootPath = Directory.GetCurrentDirectory();
builder.Logging.AddConsole();
builder.Configuration.AddJsonFile(@"D:\Files\Beast\.NET-Examples\Examples\MyHostWithDIConfigurationLoggingWorkerService\myConfig.json");
builder.Services.AddSingleton<IMessageWriter, MessageWriter>();
builder.Services.AddHostedService<MyHostedService>();
builder.Services.AddHostedService<Worker>();
await builder.Build().RunAsync();
