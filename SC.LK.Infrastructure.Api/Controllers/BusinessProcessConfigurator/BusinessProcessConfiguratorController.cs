using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.BusinessProcessConfigurator;

[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/businessProcessConfigurator/")]
[SwaggerTag("Операции с бизнес процессами ")]
[Produces("application/json")]
public class BusinessProcessConfiguratorController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public BusinessProcessConfiguratorController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Получение всех бизнес процесса
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getBusinessProcessById")]
    [SwaggerOperation("Получить один бизнес процесс по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение бизнес процесса", typeof(GetBusinessProcessByIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение бизнес процесса", typeof(GetBusinessProcessByIdResponse))]
    public async Task<IActionResult> GetBusinessProcessById([FromQuery] GetBusinessProcessByIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Изменение конфигурации версии бизнес процесса
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("saveBusinessProcessById")]
    [SwaggerOperation("Сохранить один бизнес процесс по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "Изменение конфигурации", typeof(SaveBusinessProcessByIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Изменение конфигурации", typeof(SaveBusinessProcessByIdResponse))]
    public async Task<IActionResult> SaveBusinessProcessById([FromBody] SaveBusinessProcessByIdRequest request)
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
    [Route("createBusinessProcess")]
    [SwaggerOperation("Создать пустой бизнес процесс контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание конфигурации", typeof(CreateBusinessProcessResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание конфигурации", typeof(CreateBusinessProcessResponse))]
    public async Task<IActionResult> CreateBusinessProcess([FromBody] CreateBusinessProcessRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Копирование конфигурации
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("copyBusinessProcess")]
    [SwaggerOperation("Копировать бизнес процесс контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Копировать бизнес процесс", typeof(CopyBusinessProcessResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Копировать бизнес процесс", typeof(CopyBusinessProcessResponse))]
    public async Task<IActionResult> CopyBusinessProcess([FromBody] CopyBusinessProcessRequest request)
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
    [Route("getAllBusinessProcess")]
    [SwaggerOperation("Получить все бизнес процессы контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение всех бизнес процессов", typeof(GetAllBusinessProcessResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение всех бизнес процессов", typeof(GetAllBusinessProcessResponse))]
    public async Task<IActionResult> GetAllBusinessProcess([FromQuery] GetAllBusinessProcessRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Удаление бизнес процесса
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteBusinessProcess")]
    [SwaggerOperation("Удалить бизнес процесс контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить бизнес процесс контрагента", typeof(DeleteBusinessProcessResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удалить бизнес процесс контрагента", typeof(DeleteBusinessProcessResponse))]
    public async Task<IActionResult> DeleteBusinessProcess([FromBody] DeleteBusinessProcessRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}