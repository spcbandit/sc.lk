using MediatR;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.Responses.User;

namespace SC.LK.Application.Domains.Requests.User;

public class UpdateUserRequest : IRequest<UpdateUserResponse>
{
    /// <summary>
    /// UserId
    /// </summary>
    public Guid UserId { get; set; }
    
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
    /// AvailableRoles
    /// </summary>
    public Guid AvailableRoles { get; set; }
    /// <summary>
    /// Super role
    /// </summary>
    //public bool IsSuper { get; set; }
}