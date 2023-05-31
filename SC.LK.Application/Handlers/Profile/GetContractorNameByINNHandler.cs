using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Abstractions.ExternalConnectors;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Profile;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Handlers.Profile;

public class GetContractorNameByINNHandler : IRequestHandler<GetContractorNameByINNRequest, GetContractorNameByINNResponse>
{
    private readonly IOrganizationInfoService _organizationInfoClient;
    private readonly IRepository<BillingFaceEntity> _repositoryBillingFace;

    /// <summary>
    /// Получение головной организации по ИНН 
    /// </summary>
    /// <param name="repositoryUser"></param>
    /// <param name="daDataClient"></param>
    public GetContractorNameByINNHandler(IOrganizationInfoService organizationInfoClient,
        IRepository<BillingFaceEntity> repositoryBillingFace)
    {
        _repositoryBillingFace = repositoryBillingFace ?? throw new ArgumentException(nameof(repositoryBillingFace));
        _organizationInfoClient = organizationInfoClient ?? throw new ArgumentException(nameof(organizationInfoClient));
    }

    /// <summary>
    /// Получение головной организации по ИНН 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetContractorNameByINNResponse> Handle(GetContractorNameByINNRequest request, CancellationToken cancellationToken)
    {
        if (!IsInnValid(request.INN, out var error)) 
            return new GetContractorNameByINNResponse() {Success = false, ErrorMessage = error};
        try
        {
            var value = await _organizationInfoClient.GetInfo(request.INN);
            if (value != null && value.ContractorName != string.Empty)
                return new GetContractorNameByINNResponse() {Success = true, ContractorName = value.ContractorName};
            else
                return new GetContractorNameByINNResponse()
                    {Success = false, ErrorMessage = MessageResource.InnNotFound};
        }
        catch
        {
            return new GetContractorNameByINNResponse()
                {Success = false, ErrorMessage = MessageResource.InnNotFound};
        }
    }
    
    
    /// <summary>
    /// Валидация ИНН
    /// </summary>
    /// <param name="inn"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    private bool IsInnValid(string inn, out string error)
    {
        error = string.Empty;
        var billingFaceInn = _repositoryBillingFace
            .GetWithInclude(x => x.INN == inn)
            .FirstOrDefault();
        if (billingFaceInn != null)
        {
            error = MessageResource.InnIsUsed;
            return false;
        }

        return true;
    }
}