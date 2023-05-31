using Microsoft.AspNetCore.Mvc;

namespace SC.LK.Application.Domains.Responses.Agents;

public class GetDistributiveAgentResponse : BaseResponse
{
    public FileStreamResult File {get; set; }
}