namespace SC.LK.Infrastructure.Logger;

public class LoggerOption
{
    /// <summary>
    /// LogHeaderBack
    /// </summary>
    public string LogHeaderBack { get; set; }
    
    /// <summary>
    /// IsGelfTarget
    /// </summary>
    public bool IsGelfTarget { get; set; }
    
    /// <summary>
    /// LogServerAddress
    /// </summary>
    public string LogServerAddress { get; set; }
    
    /// <summary>
    /// LogServerPort
    /// </summary>
    public string LogServerPort { get; set; }
    
    /// <summary>
    /// IsDebugTarget
    /// </summary>
    public bool IsDebugTarget { get; set; }
    
    /// <summary>
    /// IsConsoleTarget
    /// </summary>
    public bool IsConsoleTarget { get; set; }
}