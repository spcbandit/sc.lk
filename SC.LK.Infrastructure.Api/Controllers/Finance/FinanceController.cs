using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Finance;
using SC.LK.Application.Domains.Responses.Finance;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Finance;

[ApiController]
[Authorize(Policy = "AbsoluteSchema")]
[Route("/finance/")]
[SwaggerTag("Операции над финансами компании")]
[Produces("application/json")]
public class FinanceController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public FinanceController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    /// <summary>
    /// Добавление баланса
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("addBalance")]
    [SwaggerOperation("Пополнить баланс контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(AddBalanceResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(AddBalanceResponse))]
    public async Task<IActionResult> AddBalance([FromBody] AddBalanceRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получение операций
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getOperations")]
    [SwaggerOperation("Получить список всех операций")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(GetOperationsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(GetOperationsResponse))]
    public async Task<IActionResult> GetOperations([FromQuery] GetOperationsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Удаление операции
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteOperation")]
    [SwaggerOperation("Удалить операцию")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(DeleteOperationsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(DeleteOperationsResponse))]
    public async Task<IActionResult> DeleteOperations([FromBody] DeleteOperationsRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Создание билинг лица
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createBillingFace")]
    [SwaggerOperation("Создать новое платежное лицо контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(CreateBillingFaceResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(CreateBillingFaceResponse))]
    public async Task<IActionResult> CreateBillingFace([FromBody] CreateBillingFaceRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получить все билинг лица
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getAllBillingFace")]
    [SwaggerOperation("Получить список всех платежных лиц")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(GetAllBillingFaceResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(GetAllBillingFaceResponse))]
    public async Task<IActionResult> GetAllBillingFace([FromQuery] GetAllBillingFaceRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Удалить билинг лицо
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteBillingFace")]
    [SwaggerOperation("Удалить выбранное платежное лицо контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(DeleteBillingFaceResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(DeleteBillingFaceResponse))]
    public async Task<IActionResult> DeleteBillingFace([FromBody] DeleteBillingFaceRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Обновление билинг лица
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateBillingFaceById")]
    [SwaggerOperation("Обновить выбранное платежное лицо контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(UpdateBillingFaceByIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(UpdateBillingFaceByIdResponse))]
    public async Task<IActionResult> UpdateBillingFaceById([FromBody] UpdateBillingFaceByIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получение билинг лица по ID
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getBillingFaceById")]
    [SwaggerOperation("Получить платежное лицо контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание шаблона", typeof(GetBillingFaceByIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание шаблона", typeof(GetBillingFaceByIdResponse))]
    public async Task<IActionResult> GetBillingFaceById([FromQuery] GetBillingFaceByIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}
