using System.Security.Cryptography;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using SC.LK.Application.Domains.Requests.Tools;
using SC.LK.Application.Domains.Responses.Tools;

namespace SC.LK.Infrastructure.Api.Controllers.Tools;

[Authorize(Policy = "AbsoluteSchema")]
[ApiController]
[Route("/tools/")]
[SwaggerTag("Операции над инструментами")]
[Produces("application/json")]
public class ToolsController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// TerminalsController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public ToolsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Получить версию сборки
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    [Route("getBuildVersion")]
    [SwaggerOperation("Получить версию сборки")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить версию сборки", typeof(GetBuildVersionResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить версию сборки", typeof(GetBuildVersionResponse))]
    public async Task<IActionResult> GetBuildVersion()
    {
        var request = new GetBuildVersionRequest();
        var resp = await _mediator.Send(request);
        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    /// <summary>
    /// Получить хеш как у пароля
    /// </summary>
    /// <param name="SC_Authorization"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    [Route("getHashLikePassword")]
    [SwaggerOperation("Получить хеш как у пароля")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить хеш как у пароля", typeof(string))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить хеш как у пароля", typeof(string))]
    public IActionResult GetHashLikePassword([FromQuery] string str)
    {
        return Ok(GetHash(str));
        string GetHash(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            return Encoding.UTF8.GetString(sha1.ComputeHash(plainTextBytes));
        }
    }
}