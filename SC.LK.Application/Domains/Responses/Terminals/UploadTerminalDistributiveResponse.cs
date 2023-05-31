namespace SC.LK.Application.Domains.Responses.Terminals;

public class UploadTerminalDistributiveResponse:BaseResponse
{
    public Guid DistributiveId { get; set; }

    public string Version { get; set; }
}