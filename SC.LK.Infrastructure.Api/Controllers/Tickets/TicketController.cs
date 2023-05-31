using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Tickets;
using SC.LK.Application.Domains.Requests.Tools;
using SC.LK.Application.Domains.Responses.Tickets;
using SC.LK.Application.Domains.Responses.Tools;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Tickets;

[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/tickets/")]
[SwaggerTag("Операции над заявками")]
[Produces("application/json")]
public class TicketController: ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// TicketController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public TicketController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Создать заявку
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createTicket")]
    [SwaggerOperation("Создать заявку")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создать заявку", typeof(CreateTicketResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создать заявку", typeof(CreateTicketResponse))]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получить все заявки
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getAllTickets")]
    [SwaggerOperation("Получить все заявки")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить все заявки", typeof(GetAllTicketsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить все заявки", typeof(GetAllTicketsResponse))]
    public async Task<IActionResult> GetTicket([FromQuery] GetAllTicketsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Удалить заявку
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteTicket")]
    [SwaggerOperation("Удалить заявку")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить заявку", typeof(DeleteTicketResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удалить заявку", typeof(DeleteTicketResponse))]
    public async Task<IActionResult> DeleteTicket([FromBody] DeleteTicketRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Обновить заявку
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateTicket")]
    [SwaggerOperation("Обновить заявку")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновить заявку", typeof(UpdateTicketResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Обновить заявку", typeof(UpdateTicketResponse))]
    public async Task<IActionResult> UpdateTicket([FromBody] UpdateTicketRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Обновить статус заявки
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateStatusTicket")]
    [SwaggerOperation("Обновить статус заявки")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновить статус заявки", typeof(UpdateStatusTicketResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Обновить статус заявки", typeof(UpdateStatusTicketResponse))]
    public async Task<IActionResult> UpdateStatusTicket([FromBody] UpdateStatusTicketRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}