using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Admin;
using SC.LK.Application.Domains.Responses.Admin;

namespace SC.LK.Application.Handlers.Admin;

public class SwitchStatusPartnerHandler : IRequestHandler<SwitchStatusPartnerRequest, SwitchStatusPartnerResponse>
{
    private readonly IRepository<ContractorEntity> _repositoryContractor;

    public SwitchStatusPartnerHandler(IRepository<ContractorEntity> repositoryContractor)
    {
        _repositoryContractor = repositoryContractor;
    }

    public async Task<SwitchStatusPartnerResponse> Handle(SwitchStatusPartnerRequest request,
        CancellationToken cancellationToken)
    {
        var contractor = _repositoryContractor.Get(x => x.Id == request.ContractorId).FirstOrDefault();
        if (contractor != null)
        {
            contractor.Partner = request.StatusPartner;
            var res = _repositoryContractor.Update(contractor);
            if (res != 0)
                return new SwitchStatusPartnerResponse() {Success = true};
            else
                return new SwitchStatusPartnerResponse() {Success = false, ErrorMessage = MessageResource.FailedUpdateContractor};
        }
        else
            return new SwitchStatusPartnerResponse() {Success = false, ErrorMessage = MessageResource.FailedGetContractor};
    }
}