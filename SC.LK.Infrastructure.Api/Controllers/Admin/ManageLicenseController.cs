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
[Route("/admin/manageLicense/")]
[SwaggerTag("Администрирование лк")]
[Produces("application/json")]
public class ManageLicenseController: ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;
    
    /// <summary>
    /// TicketController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public ManageLicenseController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Покупка лицензии
    /// </summary>
    [HttpPost]
    [Route("addLicense")]
    [SwaggerOperation("Покупка лицензии")]
    [SwaggerResponse(StatusCodes.Status200OK, "Покупка лицензии", typeof(AddLicenseResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Покупка лицензии", typeof(AddLicenseResponse))]
    public async Task<IActionResult> AddLicense([FromBody] AddLicenseRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// Удаление лицензии
    /// </summary>
    [HttpDelete]
    [Route("deactivateLicense")]
    [SwaggerOperation("Удаление лицензии")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удаление лицензии", typeof(DeactivateLicenseResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удаление лицензии", typeof(DeactivateLicenseResponse))]
    public async Task<IActionResult> DeleteLicense([FromBody] DeactivateLicenseRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    
    /// <summary>
    /// Получение лицензии
    /// </summary>
    [HttpGet]
    [Route("getLicense")]
    [SwaggerOperation("Получение лицензии терминалов")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание терминалов", typeof(GetLicenseResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание терминалов", typeof(GetLicenseResponse))]
    public async Task<IActionResult> GetLicense([FromQuery] GetLicenseRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}