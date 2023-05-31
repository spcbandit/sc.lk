using MediatR;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Domains.Requests.ConfigurationVersion;

public class DeleteConfigurationVersionRequest : IRequest<DeleteConfigurationVersionResponse>
{
    public Guid СonfigurationVersionId { get; set; }
}