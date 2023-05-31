using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Divisions;
using SC.LK.Application.Domains.Responses.Divisions;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Divisions;

[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/divisions/")]
[SwaggerTag("Операции над подразделениями")]
[Produces("application/json")]
public class DivisionsController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public DivisionsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Получить установщик
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    [Route("getInstaller")]
    public async Task<IActionResult> GetInstaller()
    {
        byte[] fileBytes = System.IO.File.ReadAllBytes(
            Environment.CurrentDirectory + "/Installer/SC.Agent_PRD.msi");
        var memoryStream = new MemoryStream(fileBytes);
        return new FileStreamResult(memoryStream, "application/octet-stream")
        {
            FileDownloadName = "SC.Agent_PRD.msi"
        };
    }
    
    /// <summary>
    /// Получить установщик
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    [Route("getSetup")]
    public async Task<IActionResult> GetSetup()
    {
        byte[] fileBytes = System.IO.File.ReadAllBytes(
            Environment.CurrentDirectory + "/Installer/SC.AgentClient.Install.msi");
        var memoryStream = new MemoryStream(fileBytes);
        return new FileStreamResult(memoryStream, "application/octet-stream")
        {
            FileDownloadName = "SC.AgentClient.Install.msi"
        };
    }

    /// <summary>
    /// Создание подразделения
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createDivision")]
    [SwaggerOperation("Создать новое подразделение контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение создание подразделения", typeof(CreateDivisionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение создание подразделения", typeof(CreateDivisionResponse))]
    public async Task<IActionResult> CreateDivision([FromBody] CreateDivisionRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Обновление подразделения
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateDivisionById")]
    [SwaggerOperation("Обновить информацию выбранного подразделения")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение создание подразделения", typeof(UpdateDivisionByIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение создание подразделения", typeof(UpdateDivisionByIdResponse))]
    public async Task<IActionResult> UpdateDivisionById([FromBody] UpdateDivisionByIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Удаление подразделения
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteDivision")]
    [SwaggerOperation("Удалить выбранное подразделение")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удаление подразделения", typeof(DeleteDivisionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удаление подразделения", typeof(DeleteDivisionResponse))]
    public async Task<IActionResult> DeleteDivision([FromBody] DeleteDivisionRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получение всех подразделений
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getAllDivisions")]
    [SwaggerOperation("Получить список всех подразделений контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение всех подразделений", typeof(GetAllDivisionsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение всех подразделений", typeof(GetAllDivisionsResponse))]
    public async Task<IActionResult> GetAllDivisions([FromQuery] GetAllDivisionsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получение подразделения по ID
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getDivisionById")]
    [SwaggerOperation("Получить объект выбранного подразделения")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение подразделения", typeof(GetDivisionByIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение подразделения", typeof(GetDivisionByIdResponse))]
    public async Task<IActionResult> GetDivisionById([FromQuery] GetDivisionByIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}
