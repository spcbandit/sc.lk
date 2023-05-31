using MediatR;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Domains.Requests.ConfigurationVersion;

public class GetConfigurationVersionRequest : IRequest<GetConfigurationVersionResponse>
{
    public Guid ConfigurationVersionId { get; set; }
}