using Microsoft.Extensions.Logging;

namespace MyHostWithDIConfigurationLoggingWorkerService;

public class MessageWriter(ILogger<MessageWriter> logger) : IMessageWriter
{
    public void Write(string msg) => logger.LogInformation($"{nameof(MessageWriter)}: {msg}");
}