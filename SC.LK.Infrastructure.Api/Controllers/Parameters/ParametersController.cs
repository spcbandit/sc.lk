using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Instructions;
using SC.LK.Application.Domains.Requests.InstructionsParameters;
using SC.LK.Application.Domains.Responses.Instructions;
using SC.LK.Application.Domains.Responses.InstructionsParameters;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Parameters;

[ApiController]
[Route("/parameters/")]
[Authorize("AbsoluteSchema")]
[SwaggerTag("Parameters")]
[Produces("application/json")]

public class ParametersController:ControllerBase
{
    private readonly IMediator _mediator;
    public ParametersController( IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [Route("addParameters")]
 //   [Authorize]
    [SwaggerOperation("Добавить параметры")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавить параметры", typeof(AddParametersResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавить параметры", typeof(AddParametersResponse))]
    public async Task<IActionResult> AddParameters([FromBody]AddParametersRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("GetParametersByParametersId")]
  //  [Authorize]
    [SwaggerOperation("Получить параметры")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавить параметры", typeof(GetParametersByParametersIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавить параметры", typeof(GetParametersByParametersIdResponse))]
    public async Task<IActionResult> GetParametersByParametersId([FromQuery]GetParametersByParametersIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpPut]
    [Route("updateParameters")]
  //  [Authorize]
    [SwaggerOperation("Обновить параметры")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновить параметры", typeof(UpdateParametersResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Обновить параметры", typeof(UpdateParametersResponse))]
    public async Task<IActionResult> UpdateParameters([FromBody]UpdateParametersRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpDelete]
    [Route("deleteParameters")]
  //  [Authorize]
    [SwaggerOperation("Удалить параметры")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить параметры", typeof(DeleteParametersResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удалить параметры", typeof(DeleteParametersResponse))]
    public async Task<IActionResult> DeleteParameters([FromQuery]DeleteParametersRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
}