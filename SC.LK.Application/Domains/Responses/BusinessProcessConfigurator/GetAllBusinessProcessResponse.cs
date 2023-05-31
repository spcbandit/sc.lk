using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;

namespace SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

public class GetAllBusinessProcessResponse : BaseResponse
{
    public ICollection<BusinessProcessViewDto> BusinessProceses { get; set; }
}