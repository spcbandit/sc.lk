using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.AvailableRoles;
using SC.LK.Application.Domains.Requests.MethodAccess;
using SC.LK.Application.Domains.Responses.AvailableRole;
using SC.LK.Application.Domains.Responses.MethodAccess;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.MethodAccess;
[ApiController]
[Route("/methodAccess/")]
[Authorize("AbsoluteSchema")]
[SwaggerTag("Определенный доступ к методу")]
[Produces("application/json")]
public class MethodAccessController:ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public MethodAccessController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("addMethodAccess")]
    [SwaggerOperation("Добавить новый метод")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавить новый доступ к методу", typeof(AddNewMethodAccessResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавить новый доступ к методу", typeof(AddNewMethodAccessResponse))]
    public async Task<IActionResult> AddMethod([FromBody] AddNewMethodAccessRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpPost]
    [Route("bindMethodAndRoles")]
    [SwaggerOperation("Связать метод и роль")]
    [SwaggerResponse(StatusCodes.Status200OK, "Связать метод и роль", typeof(BindMethodAndRolesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Связать метод и роль", typeof(BindMethodAndRolesResponse))]
    public async Task<IActionResult> BindMethodAndRoles([FromBody] BindMethodAndRolesRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpPut]
    [Route("reBindMethodAndRoles")]
    [SwaggerOperation("Перезавязать метод и роль")]
    [SwaggerResponse(StatusCodes.Status200OK, "Перезавязать метод и роль", typeof(UpdateBindResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Перезавязать метод и роль", typeof(UpdateBindResponse))]
    public async Task<IActionResult> ReBindMethodAndRoles([FromBody] UpdateBindRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("getMethodAccess")]
    [SwaggerOperation("Получить метод")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить методы", typeof(GetMethodAccessResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить методы", typeof(GetMethodAccessResponse))]
    public async Task<IActionResult> GetMethod([FromQuery] GetMethodAccessRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("getAllMethodAccess")]
    [SwaggerOperation("Получить все методы")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить методы", typeof(GetAllMethodsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить методы", typeof(GetAllMethodsResponse))]
    public async Task<IActionResult> GetMethod([FromQuery] GetAllMethodsRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpPut]
    [Route("updateMethodAccess")]
    [SwaggerOperation("Обновить метод")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновить метод", typeof(UpdateMethodAccessResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Обновить метод", typeof(UpdateMethodAccessResponse))]
    public async Task<IActionResult> UpdateMethod([FromBody] UpdateMethodAccessRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpDelete]
    [Route("deleteMethodAccess")]
    [SwaggerOperation("Удалить метод")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить метод", typeof(DeleteMethodAccessResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удалить метод", typeof(DeleteMethodAccessResponse))]
    public async Task<IActionResult> DeleteMethod([FromQuery] DeleteMethodAccessRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpDelete]
    [Route("deleteBindingMethod")]
    [SwaggerOperation("Удалить связь метода и роли")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить метод", typeof(DeleteRolesFromMethodResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удалить метод", typeof(DeleteRolesFromMethodResponse))]
    public async Task<IActionResult> DeleteBindingMethod([FromQuery] DeleteRolesFromMethodRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
}