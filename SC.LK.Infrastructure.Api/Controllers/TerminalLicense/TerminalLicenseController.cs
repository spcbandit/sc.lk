using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.TerminalLicense;
using SC.LK.Application.Domains.Responses.TerminalLicense;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.TerminalLicense;

[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/terminalLicense/")]
[SwaggerTag("Операции над лирцензиями терминалов")]
[Produces("application/json")]
public class TerminalLicenseController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// TerminalLicenseController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public TerminalLicenseController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Получение лицензий по kontragentId
    /// </summary>
    [HttpGet]
    [Route("getLicencesByKontragent")]
    [SwaggerOperation("Получение лицензий по kontragentId")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение лицензий по kontragentId", typeof(GetLicencesByKontragentResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение лицензий по kontragentId", typeof(GetLicencesByKontragentResponse))]
    public async Task<IActionResult> GetLicencesByKontragent([FromQuery] GetLicencesByKontragentRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /*/// <summary>
    /// Обновление лицензии
    /// </summary>
    [HttpPut]
    [Route("updateLicense")]
    [Authorize(Policy = "MainSchemaReadWrite")]
    [SwaggerOperation("Обновление лицензии")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновление лицензии", typeof(UpdateLicenseResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Обновление лицензии", typeof(UpdateLicenseResponse))]
    public async Task<IActionResult> UpdateLicense([FromBody] UpdateLicenseRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }*/
    
    /*/// <summary>
    /// Добавление лицензии к терминалу
    /// </summary>
    [HttpPut]
    [Route("assignLicenceToTerminal")]
    [Authorize(Policy = "MainSchemaReadWrite")]
    [SwaggerOperation("Добавление лицензии к терминалу")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавление лицензии к терминалу", typeof(AssignLicenceToTerminalResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавление лицензии к терминалу", typeof(AssignLicenceToTerminalResponse))]
    public async Task<IActionResult> AssignLicenceToTerminal([FromBody] AssignLicenceToTerminalRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }*/
    
    /*/// <summary>
    /// Освобождение лицензии для терминала
    /// </summary>
    [HttpPut]
    [Route("releaseLicenceFromTerminal")]
    [Authorize(Policy = "MainSchemaReadWrite")]
    [SwaggerOperation("Освобождение лицензии для терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Освобождение лицензии для терминала", typeof(ReleaseLicenceFromTerminalResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Освобождение лицензии для терминала", typeof(ReleaseLicenceFromTerminalResponse))]
    public async Task<IActionResult> ReleaseLicenceFromTerminal([FromBody] ReleaseLicenceFromTerminalRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }*/
    
    /// <summary>
    /// Присвоение лицензии для терминала
    /// </summary>
    [HttpPost]
    [Route("bindLicenceToTerminal")]
    [SwaggerOperation("Присвоение лицензии для терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Присвоение лицензии для терминала", typeof(BindLicenceToTerminalResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Присвоение лицензии для терминала", typeof(BindLicenceToTerminalResponse))]
    public async Task<IActionResult> BindLicenceToTerminal([FromBody] BindLicenceToTerminalRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// Освобождение лицензии для терминала
    /// </summary>
    [HttpPost]
    [Route("releaseLicence")]
    [SwaggerOperation("Освобождение лицензии для терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Освобождение лицензии для терминала", typeof(ReleaseLicenceResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Освобождение лицензии для терминала", typeof(ReleaseLicenceResponse))]
    public async Task<IActionResult> ReleaseLicence([FromBody] ReleaseLicenceRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
   
    /// <summary>
    /// Освобождение лицензии от терминала
    /// </summary>
    [HttpGet]
    [Route("deleteTerminal")]
    [SwaggerOperation("Освобождение лицензии от терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Освобождение лицензии от терминала", typeof(DeleteTerminalLicenseResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Освобождение лицензии от терминала", typeof(DeleteTerminalLicenseResponse))]
    public async Task<IActionResult> DeleteTerminalLicense([FromQuery] DeleteTerminalLicenseRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}