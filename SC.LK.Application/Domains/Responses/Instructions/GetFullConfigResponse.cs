using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;

namespace SC.LK.Application.Domains.Responses.Instructions;

public class GetFullConfigResponse:BaseResponse
{
    public string FullConfig { get; set; }
}