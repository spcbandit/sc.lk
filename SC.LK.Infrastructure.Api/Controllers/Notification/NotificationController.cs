using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.MethodAccess;
using SC.LK.Application.Domains.Requests.Notification;
using SC.LK.Application.Domains.Responses.MethodAccess;
using SC.LK.Application.Domains.Responses.Notification;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Notification;

[ApiController]
[Route("/notification/")]
[Authorize("AbsoluteSchema")]
[SwaggerTag("Уведомления для пользователей")]
[Produces("application/json")]
public class NotificationController:ControllerBase
{
    // <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public NotificationController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("addNotification")]
    [SwaggerOperation("Добавить новое уведомление")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавить новое уведомление", typeof(AddNotificationResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавить новое уведомление", typeof(AddNotificationResponse))]
    public async Task<IActionResult> AddNoty([FromBody] AddNotificationRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("getNotification")]
    [SwaggerOperation("Получить все уведомления")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавить новое уведомление", typeof(GetNotificationResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавить новое уведомление", typeof(GetNotificationResponse))]
    public async Task<IActionResult> GetNoty([FromQuery]GetNotificationRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpDelete]
    [Route("deleteNotification")]
    [SwaggerOperation("Добавить новое уведомление")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить уведомление", typeof(DeleteNotificationResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удалить  уведомление", typeof(DeleteNotificationResponse))]
    public async Task<IActionResult> DeleteNoty([FromQuery] DeleteNotificationRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpPost]
    [Route("addNotificationByContractorId")]
    [SwaggerOperation("Добавить новое уведомление по Id контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавить новое уведомление", typeof(AddNotificationByContractorIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавить новое уведомление", typeof(AddNotificationByContractorIdResponse))]
    public async Task<IActionResult> AddNoty([FromBody] AddNotificationByContractorIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("getNotificationByContractorId")]
    [SwaggerOperation("Получить уведомления для контрагента по Id")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавить новое уведомление", typeof(GetNotificationByContractorIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавить новое уведомление", typeof(GetNotificationByContractorIdResponse))]
    public async Task<IActionResult> GetNoty([FromQuery] GetNotificationByContractorIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}