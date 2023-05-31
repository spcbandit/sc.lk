using MediatR;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Domains.Requests.ConfigurationVersion;

public class ActivateConfigurationVersionRequest : IRequest<ActivateConfigurationVersionResponse>
{
    public Guid ConfigurationVersionId { get; set; }
}