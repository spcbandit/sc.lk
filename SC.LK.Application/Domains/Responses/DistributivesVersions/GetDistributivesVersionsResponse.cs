using Newtonsoft.Json;

namespace SC.LK.Application.Domains.Responses.DistributivesVersions;

public class GetDistributivesVersionsResponse:BaseResponse
{
    public string TerminalVersion { get; set; }
    public string AgentVersion { get; set; }
    public Guid TerminalDistributiveId { get; set; }
    public Guid AgentDistributiveId { get; set; }
}