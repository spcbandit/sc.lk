using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Agents;
using SC.LK.Application.Domains.Responses.Terminals;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Terminals;

[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/terminals/")]
[SwaggerTag("Операции над терминалами")]
[Produces("application/json")]
public class TerminalsController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// TerminalsController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public TerminalsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    /// <summary>
    /// Сохранить терминал
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createTerminal")]
    [SwaggerOperation("Сохранить изменения выбранного терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение терминала по id", typeof(CreateTerminalResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение терминала по id", typeof(CreateTerminalResponse))]
    public async Task<IActionResult> CreateTerminal([FromBody] CreateTerminalRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Сохранить терминал
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateTerminal")]
    [SwaggerOperation("Сохранить изменения выбранного терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение терминала по id", typeof(UpdateTerminalResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение терминала по id", typeof(UpdateTerminalResponse))]
    public async Task<IActionResult> UpdateTerminal([FromBody] UpdateTerminalRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получить терминал по ID
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getTerminalById")]
    [SwaggerOperation("Получить объект выбранного терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение терминала по id", typeof(GetTerminalByIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение терминала по id", typeof(GetTerminalByIdResponse))]
    public async Task<IActionResult> GetTerminalById([FromQuery] GetTerminalByIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Удаление терминала
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteTerminal")]
    [SwaggerOperation("Удалить выбранный терминал")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение всех терминалов", typeof(DeleteTerminalResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение всех терминалов", typeof(DeleteTerminalResponse))]
    public async Task<IActionResult> DeleteTerminal([FromBody] DeleteTerminalRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получить терминал по ID
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getConfigurationVersionByTerminalId")]
    [SwaggerOperation("Получить объект выбранного терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение терминала по id", typeof(GetConfigurationVersionByTerminalIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение терминала по id", typeof(GetConfigurationVersionByTerminalIdResponse))]
    public async Task<IActionResult> GetConfigurationVersionByTerminalId([FromQuery] GetConfigurationVersionByTerminalIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получить терминал по ID
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getTerminalByDivisionId")]
    [SwaggerOperation("Получить объект выбранного терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение терминала по id", typeof(GetTerminalsByDivisionIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение терминала по id", typeof(GetTerminalsByDivisionIdResponse))]
    public async Task<IActionResult> GetTerminalByDivisionId([FromQuery] GetTerminalsByDivisionIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получить терминал по ID
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getTerminalByContractorId")]
    [SwaggerOperation("Получить объект выбранного терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение терминала по id", typeof(GetTerminalsByContractorIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение терминала по id", typeof(GetTerminalsByContractorIdResponse))]
    public async Task<IActionResult> GetTerminalsByContractorId([FromQuery] GetTerminalsByContractorIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получить дистрибутивы для терминала
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getDistributive")]
    [SwaggerOperation("Получить дистрибутивы для терминала")]
    public async Task<GetDistributiveTerminalResponse> GetDistributiveTerminalAsync([FromQuery] GetDistributiveTerminalRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp != null)
            return resp;
        else
            return new GetDistributiveTerminalResponse(){Success = false};
    }
    
    /// <summary>
    /// Добавление терминалов в подразделение
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("addTerminalsToDivision")]
    [SwaggerOperation("Добавление терминалов в подразделение")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавление терминалов в подразделение", typeof(AddTerminalsToDivisionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавление терминалов в подразделение", typeof(AddTerminalsToDivisionResponse))]
    public async Task<IActionResult> AddTerminalsToDivision([FromBody] AddTerminalsToDivisionRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    /// <summary>
    /// Загрузить дистрибутив терминала
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("uploadTerminalDistributive")]
    [SwaggerOperation("Загрузить дистрибутив терминала")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавление терминалов в подразделение", typeof(UploadTerminalDistributiveResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавление терминалов в подразделение", typeof(UploadTerminalDistributiveResponse))]
    public async Task<IActionResult> UploadTerminalDistributive([FromBody] UploadTerminalDistributiveRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        
        else
            return BadRequest(resp);
    }
}