using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.ConfigurationVersion;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.ConfigurationVersion;

[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/configurationVersion/")]
[SwaggerTag("Операции с версиями конфигурации")]
[Produces("application/json")]
public class ConfigurationVersionController: ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public ConfigurationVersionController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Создание конфигурации
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createConfigurationVersion")]
    [SwaggerOperation("Создать пустую версию конфигурации по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание конфигурации", typeof(CreateConfigurationsVersionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание конфигурации", typeof(CreateConfigurationsVersionResponse))]
    public async Task<IActionResult> CreateConfigurationsVersion([FromBody] CreateConfigurationsVersionRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Обновление конфигурации
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateConfigurationVersion")]
    [SwaggerOperation("Обновление версию конфигурации по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "Изменение конфигурации", typeof(UpdateConfigurationVersionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Изменение конфигурации", typeof(UpdateConfigurationVersionResponse))]
    public async Task<IActionResult> UpdateConfigurationVersion([FromBody] UpdateConfigurationVersionRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }    
    
    /// <summary>
    /// Активация конфигурации
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("activateConfigurationVersion")]
    [SwaggerOperation("Активация версии конфигурации по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "Изменение конфигурации", typeof(ActivateConfigurationVersionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Изменение конфигурации", typeof(ActivateConfigurationVersionResponse))]
    public async Task<IActionResult> ActivateConfigurationVersion([FromBody] ActivateConfigurationVersionRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Активация конфигурации
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getConfigurationVersion")]
    [SwaggerOperation("Получение версии конфигурации по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "Изменение конфигурации", typeof(GetConfigurationVersionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Изменение конфигурации", typeof(GetConfigurationVersionResponse))]
    public async Task<IActionResult> GetConfigurationVersion([FromQuery] GetConfigurationVersionRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Активация конфигурации
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteConfigurationVersionByVersionId")]
    [SwaggerOperation("Получение версии конфигурации по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "Изменение конфигурации", typeof(DeleteConfigurationVersionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Изменение конфигурации", typeof(DeleteConfigurationVersionResponse))]
    public async Task<IActionResult> DeleteConfigurationVersion([FromBody] DeleteConfigurationVersionRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Активация конфигурации
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getAllConfigurationsVersion")]
    [SwaggerOperation("Получение всех версий конфигурации по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "Изменение конфигурации", typeof(GetAllConfigurationsVersionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Изменение конфигурации", typeof(GetAllConfigurationsVersionResponse))]
    public async Task<IActionResult> GetAllConfigurationsVersion([FromQuery] GetAllConfigurationVersionRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}