using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.IdentityService.Responses;
using SC.LK.Application.Domains.InternalConnectors.IdentityService.Responses;

namespace SC.LK.Application.Abstractions;
    public partial interface IISClient
    {
        /// <summary>
        /// AuthHeader
        /// </summary>
        public string AuthHeader { get; set; }

        /// <summary>
        /// Получение пользователей по их Id
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<UserInfoResponce>> GetusersAsync(System.Collections.Generic.IEnumerable<System.Guid> usersId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Получение пользователей по их Id
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<UserInfoResponce>> GetusersAsync(System.Collections.Generic.IEnumerable<System.Guid> usersId, System.Threading.CancellationToken cancellationToken);

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Guid> CreateuserAsync(UserInfoRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Guid> CreateuserAsync(UserInfoRequest body, System.Threading.CancellationToken cancellationToken);

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UpdateuserAsync(UserInfoRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UpdateuserAsync(UserInfoRequest body, System.Threading.CancellationToken cancellationToken);

        /// <summary>
        /// Установка атрибута что удален пользователь
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task DeactivateuserAsync(System.Guid? body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Установка атрибута что удален пользователь
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task DeactivateuserAsync(System.Guid? body, System.Threading.CancellationToken cancellationToken);

        
        /// <returns>Success</returns>

        System.Threading.Tasks.Task<VersionResponse> VersionAsync();

        /// <summary>
        /// Генерация пин кода для ЛК
        /// <br/>Если текущий пин не известен передаем 0, будет сгенерирован новый
        /// <br/>Время жизни пин одни сутки, при запросе время будет продлено
        /// </summary>

        /// <param name="kontrAgentId">KontrAgentId</param>

        /// <param name="pinCode">Пин код текущий, если не известен тогда 0</param>

        /// <returns>Текущий пин</returns>

        public abstract System.Threading.Tasks.Task<string> GetPinCodeAsync(System.Guid? kontrAgentId, int? pinCode);

        
        /// <summary>
        /// Проверка пина для сайт агента и добавление в cloud api
        /// </summary>

        /// <param name="pinCode">Пин для проверки</param>

        /// <returns>Success</returns>

        System.Threading.Tasks.Task<UserSiteAgentModel> CheckPinForAgentAsync(int? pinCode);
        
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Guid> CreateroleAsync(UserRoleRequest body);
        
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Guid> CreateroleAsync(UserRoleRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UserRoleResponce> GetroleAsync(System.Guid? roleId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UserRoleResponce> GetroleAsync(System.Guid? roleId, System.Threading.CancellationToken cancellationToken);

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task DeleteroleAsync(System.Guid? body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task DeleteroleAsync(System.Guid? body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UpdateroleAsync(UserRoleRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UpdateroleAsync(UserRoleRequest body, System.Threading.CancellationToken cancellationToken);

        /// <summary>
        /// Получение токена
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ResponseToken> TokenAsync(LoginRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Получение токена
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ResponseToken> TokenAsync(LoginRequest body, System.Threading.CancellationToken cancellationToken);

        /// <summary>
        /// Аутентификация токена
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task GetresultAsync();

    }
