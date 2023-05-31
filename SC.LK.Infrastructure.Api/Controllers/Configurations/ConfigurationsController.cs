using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Configurations;
using SC.LK.Application.Domains.Responses.Configurations;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Configurations;

[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/configurations/")]
[SwaggerTag("Операции над всеми конфигурациями")]
[Produces("application/json")]
public class ConfigurationsController: ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public ConfigurationsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Получение всех конфигураций
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getAllConfigurations")]
    [SwaggerOperation("Получить все конфигурации контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение всех конфигураций", typeof(GetAllConfigurationsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение всех конфигураций", typeof(GetAllConfigurationsResponse))]
    public async Task<IActionResult> GetAllConfigurations([FromQuery] GetAllConfigurationsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Создание конфигурации
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createConfiguration")]
    [SwaggerOperation("Создать пустую конфигурацию контрагент")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание конфигурации", typeof(CreateConfigurationsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание конфигурации", typeof(CreateConfigurationsResponse))]
    public async Task<IActionResult> CreateConfigurations([FromBody] CreateConfigurationsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получение всех бизнес процессов
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getAllDivisionsTerminals")]
    [SwaggerOperation("Получить список всех подразделений контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение всех подразделений", typeof(GetAllDivisionsTerminalsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение всех подразделений", typeof(GetAllDivisionsTerminalsResponse))]
    public async Task<IActionResult> GetAllDivisionsTerminals([FromQuery] GetAllDivisionsTerminalsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}
