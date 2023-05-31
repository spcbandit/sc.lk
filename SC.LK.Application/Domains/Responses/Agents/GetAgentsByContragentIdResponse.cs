using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.Agents;

public class GetAgentsByContragentIdResponse : BaseResponse
{
    public AgentsViewDto Agents { get; set; }
}