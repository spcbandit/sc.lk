using MediatR;
using SC.LK.Application.Domains.Responses.Admin;

namespace SC.LK.Application.Domains.Requests.Admin;

public class GetLicenseRequest : IRequest<GetLicenseResponse>
{
    public Guid LicenseId { get; set; }
}