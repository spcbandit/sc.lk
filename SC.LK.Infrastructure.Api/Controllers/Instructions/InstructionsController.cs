
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Instructions;
using SC.LK.Application.Domains.Responses.Instructions;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Instructions;

[ApiController]
[Microsoft.AspNetCore.Authorization.Authorize(Policy = "AbsoluteSchema")]
[Route("/instructions/")]
[SwaggerTag("Instructions")]
[Produces("application/json")]

public class InstructionsController : ControllerBase
{
    private readonly IMediator _mediator;
    public InstructionsController( IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [Route("addInstructions")]
    [SwaggerOperation("Добавить инструкцию")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавить инструкцию", typeof(AddInstructionsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавить инструкцию", typeof(AddInstructionsResponse))]
    public async Task<IActionResult> AddInstructions([Microsoft.AspNetCore.Mvc.FromBody]AddInstructionsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpPut]
    [Route("updateInstructions")]
    [SwaggerOperation("Обновить инструкцию")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(UpdateInstructionsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(UpdateInstructionsResponse))]
    public async Task<IActionResult> UpdateInstructions([Microsoft.AspNetCore.Mvc.FromBody, FromRoute]UpdateInstructionsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("getInstructionsByInstructionsId")]
    [SwaggerOperation("Получить инструкцию")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(UpdateInstructionsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(UpdateInstructionsResponse))]
    public async Task<IActionResult> GetInstructionsByInstructionsId([FromQuery]GetInstructionsByInstructionsIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpDelete]
    [Route("delete")]
    [SwaggerOperation("Удалить инструкцию")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(DeleteInstructionsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(DeleteInstructionsResponse))]
    public async Task<IActionResult> DeleteInstructions([FromQuery]DeleteInstructionsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("getFullInstructions")]
    [SwaggerOperation("Получить инструкцию")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(GetFullConfigResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(GetFullConfigResponse))]
    public async Task<IActionResult> GetFullConfig([FromQuery]GetFullConfigRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}