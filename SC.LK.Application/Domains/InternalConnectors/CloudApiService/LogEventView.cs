namespace SC.LK.Application.Domains.CloudApiService;

public partial class LogEventView
{
    [Newtonsoft.Json.JsonProperty("eventSource")]
    public string EventSource { get; set; }

    [Newtonsoft.Json.JsonProperty("sourceId")]
    public System.Guid SourceId { get; set; }

    [Newtonsoft.Json.JsonProperty("eventCategory")]
    public LogLevelEnum EventCategory { get; set; }

    [Newtonsoft.Json.JsonProperty("message")]
    public string Message { get; set; }

}
public enum LogLevelEnum
{

    _0 = 0,

    _1 = 1,

    _2 = 2,

    _3 = 3,

}