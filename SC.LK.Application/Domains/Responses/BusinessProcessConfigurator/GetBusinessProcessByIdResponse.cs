using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

public class GetBusinessProcessByIdResponse : BaseResponse
{
    public BusinessProcessViewDto BusinessProcess { get; set; }
    public Style ConfigurationStyle { get; set; }
    public string ConfigurationHtml { get; set; }
}