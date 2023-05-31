using MediatR;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Domains.Requests.Agents;

public class UpdateAgentRequest : IRequest<UpdateAgentResponse>
{
  public  Guid AgentId { get; set; }
  
  public AgentView Agent { get; set; }
}