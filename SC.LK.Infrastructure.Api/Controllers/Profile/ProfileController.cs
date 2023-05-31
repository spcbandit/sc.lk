﻿using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 using NLog;
 using SC.LK.Application.Abstractions.Logging;
 using SC.LK.Application.Domains.Requests.Profile;
using SC.LK.Application.Domains.Responses.Profile;
using Swashbuckle.AspNetCore.Annotations;

namespace SC.LK.Infrastructure.Api.Controllers.Profile;

[ApiController]
[Route("/profile/")]
[SwaggerTag("Операции над основным пользователем лк")]
[Produces("application/json")]
public class ProfileController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ProfileController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public ProfileController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Изменение данных пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("changeData")]
    [SwaggerOperation("Изменить информацию основного пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Изменение данных пользователя", typeof(ChangeDataResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Изменение данных пользователя", typeof(ChangeDataResponse))]
    public async Task<IActionResult> ChangeData([FromBody] ChangeDataRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// Получение данных пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getUserInfo")]
    [SwaggerOperation("Получить информацию верхнего уровня основного пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Изменение данных пользователя", typeof(GetUserInfoResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Изменение данных пользователя", typeof(GetUserInfoResponse))]
    public async Task<IActionResult> GetUserInfo([FromQuery] GetUserInfoRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// login
    /// </summary>
    /// <param name="request">LoginRequest</param>
    /// <returns></returns>
    [HttpPut]
    [Route("login")]
    [AllowAnonymous]
    [SwaggerOperation("Вход в личный кабинет, выдача токена")]
    [SwaggerResponse(StatusCodes.Status200OK, "Логин партнера", typeof(LoginResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Логин партнера", typeof(LoginResponse))]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// CreateNewPassword
    /// </summary>
    /// <param name="request">CreateNewPassword</param>
    /// <returns></returns>
    [HttpPost]
    [Route("createNewPassword")]
    [AllowAnonymous]
    [SwaggerOperation("Создание нового пароля нового пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создание нового пароля нового пользователя", typeof(LoginResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание нового пароля нового пользователя", typeof(LoginResponse))]
    public async Task<IActionResult> CreateNewPassword([FromBody] CreateNewPasswordRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// logout
    /// </summary>
    /// <param name="request">LogoutRequest</param>
    /// <returns></returns>
    [HttpPut]
    [Route("logout")]
    [SwaggerOperation("Выход из лк удаление токена")]
    [SwaggerResponse(StatusCodes.Status200OK, "Выход партнера", typeof(LogoutResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Выход партнера", typeof(LogoutResponse))]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// Регистрация 
    /// </summary>
    /// <param name="request">RegistrationRequest</param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    [Route("registration")]
    [SwaggerOperation("Регистрация основного пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Регистрация партнера", typeof(RegistrationResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Регистрация партнера", typeof(RegistrationResponse))]
    public async Task<IActionResult> Registration([FromBody] RegistrationRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Получение имени контрагента по ИНН
    /// </summary>
    /// <param name="request">RegistrationRequest</param>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    [Route("getContractorNameByINN")]
    [SwaggerOperation("Проверка по ИНН компании")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение имени контрагента по ИНН", typeof(GetContractorNameByINNResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение имени контрагента по ИНН", typeof(GetContractorNameByINNResponse))]
    public async Task<IActionResult> GetContractorNameByINN([FromQuery] GetContractorNameByINNRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Востановление пароля
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [AllowAnonymous]
    [Route("passwordReset")]
    [SwaggerResponse(StatusCodes.Status200OK, "Сменить пароль", typeof(PasswordResetResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Сменить пароль = false", typeof(PasswordResetResponse))]
    public async Task<IActionResult> PasswordReset([FromBody] PasswordResetRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Отправка кода
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [AllowAnonymous]
    [Route("sendCode")]
    [SwaggerResponse(StatusCodes.Status200OK, "Отправить код", typeof(SendCodeResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Отправить код = false", typeof(SendCodeResponse))]
    public async Task<IActionResult> SendCode([FromBody] SendCodeRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// Проверка кода
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [AllowAnonymous]
    [Route("validateCode")]
    [SwaggerResponse(StatusCodes.Status200OK, "Сверить код", typeof(ValidateCodeResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Сверить код = false", typeof(ValidateCodeResponse))]
    public async Task<IActionResult> ValidateCode([FromBody] ValidateCodeRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}
