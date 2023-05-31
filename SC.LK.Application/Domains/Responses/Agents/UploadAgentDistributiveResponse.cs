namespace SC.LK.Application.Domains.Responses.Agents;

public class UploadAgentDistributiveResponse:BaseResponse
{
    public Guid DistributiveId { get; set; }

    public string Version { get; set; }
}