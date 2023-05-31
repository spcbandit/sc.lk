namespace SC.LK.Application.Abstractions.Logging;

public interface ILoggerContext
{
    public string Header { get; set; }
    public NLog.ILogger GetLogger();
    public string PreparingMessage(string type, object obj);
}