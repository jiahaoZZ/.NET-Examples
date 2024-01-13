using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyHostWithDIConfigurationLoggingWorkerService;

public class MyHostedService : IHostedService
{
    private readonly ILogger<MyHostedService> _logger;

    public MyHostedService(ILogger<MyHostedService> logger, IHostApplicationLifetime hostApplicationLifetime)
    {
        _logger = logger;
        hostApplicationLifetime.ApplicationStarted.Register(() => _logger.LogInformation("ApplicationStarted"));
        hostApplicationLifetime.ApplicationStopped.Register(() => _logger.LogInformation("ApplicationStopped"));
        hostApplicationLifetime.ApplicationStopping.Register(() => _logger.LogInformation("ApplicationStopping"));
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(StartAsync)} is called");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(StopAsync)} is called");
        return Task.CompletedTask;
    }
}