using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.ParametersValues;
using SC.LK.Application.Domains.Responses.InstructionsParameters;
using SC.LK.Application.Domains.Responses.ParametersValues;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.ParametersValues;

[ApiController]
[Route("/parametersValues/")] 
[Authorize(Policy = "AbsoluteSchema")]
[SwaggerTag("ParametersValues")]
[Produces("application/json")]
public class ParametersValuesController:ControllerBase
{
    private readonly IMediator _mediator;
    public ParametersValuesController( IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [Route("addParametersValues")]
    [SwaggerOperation("Добавить настройки параметров")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавить настройки параметров", typeof(AddParametersValuesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавить настройки параметров", typeof(AddParametersValuesResponse))]
    public async Task<IActionResult> AddParametersValues([FromBody]AddParametersValuesRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("GetParametersValuesByParametersValuesId")]
    [SwaggerOperation("Получить параметры")]
    [SwaggerResponse(StatusCodes.Status200OK, "Добавить параметры", typeof(GetParametersValuesByParametersValuesIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Добавить параметры", typeof(GetParametersValuesByParametersValuesIdResponse))]
    public async Task<IActionResult> GetParametersValuesByParametersValuesId([FromQuery]GetParametersValuesByParametersValuesIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpPut]
    [Route("updateParametersValues")]
    [SwaggerOperation("Обновить параметры")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновить параметры", typeof(UpdateParametersValuesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Обновить параметры", typeof(UpdateParametersValuesResponse))]
    public async Task<IActionResult> UpdateParametersValues([FromBody]UpdateParametersValuesRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpDelete]
    [Route("deleteParametersValues")]
    [SwaggerOperation("Удалить параметры")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить параметры", typeof(DeleteParametersValuesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Удалить параметры", typeof(DeleteParametersValuesResponse))]
    public async Task<IActionResult> DeleteParametersValues([FromQuery]DeleteParametersValuesRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}