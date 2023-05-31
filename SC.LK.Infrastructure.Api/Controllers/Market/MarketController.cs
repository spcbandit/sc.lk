using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Instructions;
using SC.LK.Application.Domains.Requests.Market;
using SC.LK.Application.Domains.Responses.Market;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Market;
[ApiController]
[Microsoft.AspNetCore.Authorization.Authorize(Policy = "AbsoluteSchema")]
[Route("/market/")]
[SwaggerTag("Market")]
[Produces("application/json")]
public class MarketController:ControllerBase
{
    private readonly IMediator _mediator;

    public MarketController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    [Route("getAllItemForSale")]
    [SwaggerOperation("Получить все продукты на продажу")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить все продукты на продажу", typeof(GetAllItemForSaleResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить все продукты на продажу", typeof(GetAllItemForSaleResponse))]
    public async Task<IActionResult> GetAllItemsForSale([FromQuery]GetAllItemForSaleRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("GetItemForSaleByItemForSaleId")]
    [SwaggerOperation("Получить продукт по id на продажу")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить продукт по id на продажу", typeof(GetItemForSaleByIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить продукт по id на продажу", typeof(GetItemForSaleByIdResponse))]
    public async Task<IActionResult> GetItemForSaleByItemForSaleId([FromQuery]GetItemForSaleByIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpGet]
    [Route("getAllTemplatesByContragentId")]
    [SwaggerOperation("Получить список темплейтов по айди контрагента")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить список темплейтов по айди контрагента", typeof(GetTemplatesByContragentResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить список темплейтов по айди контрагента", typeof(GetTemplatesByContragentResponse))]
    public async Task<IActionResult> GetItemForSaleByItemForSaleId([FromQuery]GetTemplatesByContragentRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpPost]
    [Route("notifyAdminItemBuy")]
    [SwaggerOperation("Уведомление админу о запросе покупки")]
    [SwaggerResponse(StatusCodes.Status200OK, "Уведомление админу о запросе покупки", typeof(NotifyAdminItemBuyResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Уведомление админу о запросе покупки", typeof(NotifyAdminItemBuyResponse))]
    public async Task<IActionResult> NotifyAdminItemBuy([FromBody]NotifyAdminItemBuyRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    [HttpPost]
    [Route("createBPByItemForSaleId")]
    [SwaggerOperation("Уведомление админу о запросе покупки")]
    [SwaggerResponse(StatusCodes.Status200OK, "Уведомление админу о запросе покупки", typeof(CreateBPByItemForSaleIdResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Уведомление админу о запросе покупки", typeof(CreateBPByItemForSaleIdResponse))]
    public async Task<IActionResult> CreateBPByItemForSaleId([FromBody]CreateBPByItemForSaleIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
}