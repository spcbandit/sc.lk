using SC.LK.Application.Domains.IdentityService.Responses;

namespace SC.LK.Application.Domains.IdentityService.Requests
{
    public class UserInfoResponce
    {
        public Guid UserId { get; set; }

        /// <summary>
        /// Активен ли аккаунт
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string? Parent { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? Family { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; } = null!;

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// ServiceId
        /// </summary>
        public ICollection<Services> ServiceId { get; set; } = null!;

        /// <summary>
        /// Удален ли аккаунт
        /// </summary>
        public bool? IsDelete { get; set; }

        /// <summary>
        /// UsersRoles
        /// </summary>
        public virtual ICollection<UsersRoles>? UsersRoles { get; set; }
    }
}