using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.Contractors;
using SC.LK.Application.Domains.Responses.Contractors;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Contractor
{
    [ApiController]
    [Authorize(Policy = "AbsoluteSchema")]
    [Route("/contractor/")]
    [SwaggerTag("Операции над контрагентами")]
    [Produces("application/json")]
    public class ContractorController : ControllerBase
    {
        /// <summary>
        /// Request to handlers
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// ChatController
        /// </summary>
        /// <param name="mediator">mediator</param>
        public ContractorController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        /// <summary>
        /// Получение контагентов
        /// </summary>
        /// <param name="SC_Authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getContractors")]
        [SwaggerOperation("Получить объект выбранного контрагента")]
        [SwaggerResponse(StatusCodes.Status200OK, "Получение контрагента", typeof(GetContractorsResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение контрагента", typeof(GetContractorsResponse))]
        public async Task<IActionResult> GetContractors([FromQuery] GetContractorsRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
        
        /// <summary>
        /// Получение пинкода по контрагенту
        /// </summary>
        /// <param name="SC_Authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getPinCodeByContragentId")]
        [SwaggerOperation("Получить пинкода по контрагенту")]
        [SwaggerResponse(StatusCodes.Status200OK, "Получение пинкода по контрагенту", typeof(GetPinCodeResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение пинкода по контрагенту", typeof(GetPinCodeResponse))]
        public async Task<IActionResult> GetPincode([FromQuery] GetPincodeRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
        
        /// <summary>
        /// Создание дочернего контрагента
        /// </summary>
        /// <param name="SC_Authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createChildContragent")]
        [SwaggerOperation("Создание дочернего контрагента")]
        [SwaggerResponse(StatusCodes.Status200OK, "Создание дочернего контрагента", typeof(CreateChildContragentResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание дочернего контрагента", typeof(CreateChildContragentResponse))]
        public async Task<IActionResult> CreateChildContragent([FromBody] CreateChildContragentRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
        
        /// <summary>
        /// Получение дочерних контрагентов
        /// </summary>
        /// <param name="SC_Authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getChildContragents")]
        [SwaggerOperation("Получение дочерних контрагентов")]
        [SwaggerResponse(StatusCodes.Status200OK, "Получение дочерних контрагентов", typeof(GetChildContragentsResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение дочерних контрагентов", typeof(GetChildContragentsResponse))]
        public async Task<IActionResult> GetChildContragents([FromQuery] GetChildContragentsRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
        
        
        [HttpGet]
        [Route("getContractorNameById")]
        [AllowAnonymous]
        [SwaggerOperation("Получение имени контрагента по id")]
        [SwaggerResponse(StatusCodes.Status200OK, "Получение имени контрагента по id", typeof(GetContractorNameByIdResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение имени контрагента по id", typeof(GetContractorNameByIdResponse))]
        public async Task<IActionResult> GetContractorNameById([FromQuery] GetContractorNameByIdRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
    }
}