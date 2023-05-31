using MediatR;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Domains.Requests.ConfigurationVersion;

public class GetAllConfigurationVersionRequest : IRequest<GetAllConfigurationsVersionResponse>
{
    public Guid ConfigurationId { get; set; }
}