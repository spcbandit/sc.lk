using MediatR;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Responses.InstructionsParameters;

namespace SC.LK.Application.Domains.Requests.InstructionsParameters;

public class UpdateParametersRequest:IRequest<UpdateParametersResponse>
{ 
    public InstructionsParameterDto ParameterDto { get; set; }
}