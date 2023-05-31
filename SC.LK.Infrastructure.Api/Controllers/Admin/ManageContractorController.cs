using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Admin;
using SC.LK.Application.Domains.Responses.Admin;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Admin;


[Authorize(Policy = "AbsoluteSchema")]
[ApiController]
[Route("/admin/manageContractor/")]
[SwaggerTag("Администрирование лк")]
[Produces("application/json")]
public class ManageContractorController: ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;
    
    /// <summary>
    /// TicketController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public ManageContractorController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Изменить статус партнера
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("switchStatusPartner")]
    [SwaggerOperation("Изменить статус партнера")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создать заявку", typeof(SwitchStatusPartnerResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создать заявку", typeof(SwitchStatusPartnerResponse))]
    public async Task<IActionResult> SwitchStatusPartner([FromBody] SwitchStatusPartnerRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
}