using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Requests.AvailableRoles;
using SC.LK.Application.Domains.Responses.Agents;
using SC.LK.Application.Domains.Responses.AvailableRole;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.AvailableRoles;
[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/availableRoles/")]
[SwaggerTag("Доступные общие роли и пермишены")]
[Produces("application/json")]
public class AvailableRolesController:ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public AvailableRolesController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("addAvailableRoles")]
    [SwaggerOperation("Создать новую общую роль")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создать новую общую роль", typeof(AddAvailableRoleResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создать новую общую роль", typeof(AddAvailableRoleResponse))]
    public async Task<IActionResult> AddAvailableRoles([FromBody] AddAvailableRoleRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("getAvailableRoles")]
    [SwaggerOperation("Получить общую роль")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить общую роль", typeof(GetAvailableRolesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить общую роль", typeof(GetAvailableRolesResponse))]
    public async Task<IActionResult> GetAvailableRoles([FromQuery] GetAvailableRolesRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("getAllAvailableRoles")]
    [SwaggerOperation("Получить все общие роли")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить все общие роли", typeof(GetAllAvailableRolesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить все общие роли", typeof(GetAllAvailableRolesResponse))]
    public async Task<IActionResult> GetAllAvailableRoles([FromQuery]GetAllAvailableRolesRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpPut]
    [Route("updateAvailableRoles")]
    [SwaggerOperation("Обновить общую роль")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновить общую роль", typeof(UpdateAvailableRolesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Обновить общую роль", typeof(UpdateAvailableRolesResponse))]
    public async Task<IActionResult> UpdateAvailableRoles([FromBody] UpdateAvailableRolesRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpDelete]
    [Route("deleteAvailableRoles")]
    [SwaggerOperation("Удалить общую роль")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить общую роль", typeof(DeleteAvailableRoleResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удалить общую роль", typeof(DeleteAvailableRoleResponse))]
    public async Task<IActionResult> DeleteAvailableRoles([FromBody] DeleteAvailableRoleRequest  request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}