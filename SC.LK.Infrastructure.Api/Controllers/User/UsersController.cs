using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Requests.User;
using SC.LK.Application.Domains.Responses.User;
using Swashbuckle.AspNetCore.Annotations;
using CreateUserRequest = SC.LK.Application.Domains.Requests.User.CreateUserRequest;
using CreateUserResponse = SC.LK.Application.Domains.Responses.User.CreateUserResponse;


namespace SC.LK.Infrastructure.Api.Controllers.User
{
    [ApiController]
    [Authorize(Policy = "AbsoluteSchema")]
    [Route("/users/")]
    [SwaggerTag("Операции над дочерними пользователями")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Request to handlers
        /// </summary>
        private readonly IMediator _mediator;
        
        /// <summary>
        /// ChatController
        /// </summary>
        /// <param name="mediator">mediator</param>
        public UsersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="SC_Authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createUser")]
        [SwaggerOperation("Создание нового пользователя")]
        [SwaggerResponse(StatusCodes.Status200OK, "Создание пользователя", typeof(CreateUserResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание пользователя", typeof(CreateUserResponse))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
        
        /// <summary>
        /// Получить доступные роли
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllRoles")]
        [SwaggerOperation("Получить доступные роли")]
        [SwaggerResponse(StatusCodes.Status200OK, "Получить доступные роли", typeof(GetAllRolesResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Получить доступные роли", typeof(GetAllRolesResponse))]
        public async Task<IActionResult> GetAllRoles()
        {
            var resp = await _mediator.Send(new GetAllRolesRequest());

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
        
        /// <summary>
        /// Получить доступные пермишены
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <param name="SC_Authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllUsers")]
        [SwaggerOperation("Получить список всех дочерних пользователей")]
        [SwaggerResponse(StatusCodes.Status200OK, "Получение всех пользователей", typeof(GetAllUsersResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Получение всех пользователей", typeof(GetAllUsersResponse))]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
        
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="SC_Authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteUser")]
        [SwaggerOperation("Удалить дочернего пользователя")]
        [SwaggerResponse(StatusCodes.Status200OK, "Удаление пользователя", typeof(DeleteUserResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Удаление пользователя", typeof(DeleteUserResponse))]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
        
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="SC_Authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateUser")]
        [SwaggerOperation("Обновить информацию дочернего пользователя")]
        [SwaggerResponse(StatusCodes.Status200OK, "Изменение пользователя", typeof(UpdateUserResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Изменение пользователя", typeof(UpdateUserResponse))]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
        [HttpPut]
        [Route("addFlag")]
        [SwaggerOperation("Добавить флаг для дочернего пользователя")]
        [SwaggerResponse(StatusCodes.Status200OK, "Изменение пользователя", typeof(AddFlagToUserResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Изменение пользователя", typeof(AddFlagToUserResponse))]
        public async Task<IActionResult> AddFlag([FromBody] AddFlagToUserRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
    }
}

