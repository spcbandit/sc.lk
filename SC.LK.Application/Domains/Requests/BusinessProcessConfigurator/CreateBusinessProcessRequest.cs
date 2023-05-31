using MediatR;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;

public class CreateBusinessProcessRequest: IRequest<CreateBusinessProcessResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }

    /// <summary>
    /// NameBusinessProcess
    /// </summary>
    public string NameBusinessProcess { get; set; }
    
}