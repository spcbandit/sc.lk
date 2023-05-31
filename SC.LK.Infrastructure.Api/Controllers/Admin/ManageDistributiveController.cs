using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.DistributivesVersions;
using SC.LK.Application.Domains.Requests.Instructions;
using SC.LK.Application.Domains.Responses.DistributivesVersions;
using SC.LK.Application.Domains.Responses.Instructions;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Admin;
[ApiController]
[Microsoft.AspNetCore.Authorization.Authorize(Policy = "AbsoluteSchema")]
[Route("/admin/")]
[SwaggerTag("ManageDistributiveController")]
[Produces("application/json")]
public class ManageDistributiveController:ControllerBase
{
    private readonly IMediator _mediator;
    public ManageDistributiveController( IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    [Route("getDistributives")]
    [SwaggerOperation("Получить версии дистрибутивов агента и терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить версии дистрибутивов", typeof(GetDistributivesVersionsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить версии дистрибутивов", typeof(GetDistributivesVersionsResponse))]
    public async Task<IActionResult> GetDistributives([FromQuery]GetDistributivesVersionsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}