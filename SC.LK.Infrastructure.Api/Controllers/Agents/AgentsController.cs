using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Responses.Agents;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Agents;

[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/agents/")]
[SwaggerTag("Операции с Агентами системы")]
[Produces("application/json")]
public class AgentsController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public AgentsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Получение всех агентов по контрагенту
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getAgentsByContragentId")]
    [SwaggerOperation("Получить всех агентов по контрагенту")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение всех агентов по контрагенту", typeof(GetAgentsByContragentIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение всех агентов по контрагенту", typeof(GetAgentsByContragentIdResponse))]
    public async Task<IActionResult> GetAgentsByContragentId([FromQuery] GetAgentsByContragentIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// Получение всех агентов по подразделению
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getAgentsByDivisionId")]
    [SwaggerOperation("Получить всех агентов по подразделению")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение всех агентов по подразделению", typeof(GetAgentsByDivisionIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение всех агентов по подразделению", typeof(GetAgentsByDivisionIdResponse))]
    public async Task<IActionResult> GetAgentsByDivisionId([FromQuery] GetAgentsByDivisionIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// Добавление агентов в подразделение
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("setAgentsInDivision")]
    [SwaggerOperation("Добавить агентов в подразделение")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавление агентов в подразделение", typeof(SetAgentsInDivisionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавление агентов в подразделение", typeof(SetAgentsInDivisionResponse))]
    public async Task<IActionResult> SetAgentsByDivisionId([FromBody] SetAgentsInDivisionRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// Добавление агентов в подразделение
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateAgent")]
    [SwaggerOperation("Добавить агентов в подразделение")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавление агентов в подразделение", typeof(UpdateAgentResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавление агентов в подразделение", typeof(UpdateAgentResponse))]
    public async Task<IActionResult> UpdateAgent([FromBody] UpdateAgentRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// Получить дистрибутив
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getDistributive")]
    [SwaggerOperation("Получить дистрибутивы")]
    public async Task<IActionResult> GetDistributiveAgentAsync([FromQuery] GetDistributiveAgentRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp != null)
            return resp;
        else
            return BadRequest(resp);
    }
    /// <summary>
    /// Отправить дистрибутив
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("uploadAgentDistributive")]
    [SwaggerOperation("Отправить дистрибутивы")]
    public async Task<IActionResult> UploadAgentDistributive([FromForm] UploadAgentDistributiveRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }


    [HttpDelete]
    [Route("deleteAgentByAgentId")]
    [SwaggerOperation("Удалить агента по ID")]
    [SwaggerResponse (StatusCodes.Status200OK, "Удаление агента в подразделении", typeof(DeleteAgentByAgentIdResponce))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удаление агента в подразделении", typeof(DeleteAgentByAgentIdResponce))]
    public async Task<IActionResult> DeleteAgentByAgentId([FromQuery] DeleteAgentByAgentIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

}