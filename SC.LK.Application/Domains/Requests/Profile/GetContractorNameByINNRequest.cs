using MediatR;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.Requests.Profile;

public class GetContractorNameByINNRequest : IRequest<GetContractorNameByINNResponse>
{
    /// <summary>
    /// ИНН
    /// </summary>
    public string INN { get; set; }
}