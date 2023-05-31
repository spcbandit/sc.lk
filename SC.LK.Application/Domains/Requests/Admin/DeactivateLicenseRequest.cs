using MediatR;
using SC.LK.Application.Domains.Responses.Admin;

namespace SC.LK.Application.Domains.Requests.Admin;

public class DeactivateLicenseRequest : IRequest<DeactivateLicenseResponse>
{
    public Guid LicenseId { get; set; }
}