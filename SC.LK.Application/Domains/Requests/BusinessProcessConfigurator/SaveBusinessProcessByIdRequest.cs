using MediatR;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;

public class SaveBusinessProcessByIdRequest : IRequest<SaveBusinessProcessByIdResponse>
{
    public Guid BusinessProcessId { get; set; }
    public string JsonConfiguration { get; set; }
}