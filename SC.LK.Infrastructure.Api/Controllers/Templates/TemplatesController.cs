using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Templates;
using SC.LK.Application.Domains.Responses.Templates;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Templates;

[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/templates/")]
[SwaggerTag("Операции над шаблонами конфигурации")]
[Produces("application/json")]
public class TemplatesController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public TemplatesController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    /// <summary>
    /// Создание шаблона
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createTemplate")]
    [SwaggerOperation("Создать шаблон конфигурации")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(CreateTemplatesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(CreateTemplatesResponse))]
    public async Task<IActionResult> CreateTemplates([FromForm] CreateTemplatesRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получение всех шаблонов
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getAllTemplates")]
    [SwaggerOperation("Получить список всех шаблонов")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение всех шаблонов", typeof(GetAllTemplatesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение всех шаблонов", typeof(GetAllTemplatesResponse))]
    public async Task<IActionResult> GetAllTemplates([FromQuery] GetAllTemplatesRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// Удаление шаблона
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteTemplate")]
    [SwaggerOperation("Удаление выбранного шаблона")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение всех шаблонов", typeof(DeleteTemplatesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение всех шаблонов", typeof(DeleteTemplatesResponse))]
    public async Task<IActionResult> DeleteTemplates([FromForm] DeleteTemplatesRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получение шаблона по ID
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getTemplateById")]
    [SwaggerOperation("Получить объект выбранного шаблона")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение шаблона по Id", typeof(GetTemplateByIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение шаблона по Id", typeof(GetTemplateByIdResponse))]
    public async Task<IActionResult> GetTemplateById([FromQuery] GetTemplateByIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Обновление шаблона
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateTemplateById")]
    [SwaggerOperation("Обновление выбранного шаблона")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновление шаблона", typeof(UpdateTemplateByIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Обновление шаблона", typeof(UpdateTemplateByIdResponse))]
    public async Task<IActionResult> UpdateTemplateById([FromForm] UpdateTemplateByIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}