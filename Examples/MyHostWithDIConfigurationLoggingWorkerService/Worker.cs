using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyHostWithDIConfigurationLoggingWorkerService;

public class Worker(IConfiguration config, IMessageWriter messageWriter) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            messageWriter.Write($"WorkerService is executing at {DateTime.Now}, Author is {config.GetValue<string>("MyConfig:Name")}");
            await Task.Delay(1000, stoppingToken);
        }
    }
}