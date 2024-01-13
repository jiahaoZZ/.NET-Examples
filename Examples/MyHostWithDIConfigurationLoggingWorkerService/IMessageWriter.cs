namespace MyHostWithDIConfigurationLoggingWorkerService;

public interface IMessageWriter
{
    void Write(string msg);
}