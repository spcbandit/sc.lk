using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.Responses.User;

namespace SC.LK.Application.Domains.Requests.User;

public class CreateUserRequest : IRequest<CreateUserResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }    
    
    /// <summary>
    /// UserId - создателя
    /// </summary>
    public Guid CreatorUserId { get; set; }

    /// <summary>
    /// Login
    /// </summary>
    [DefaultValue("Login")]
    public string Login { get; set; } = null!;

    /// <summary>
    /// Установить доступную роль и пермишен
    /// </summary>
    public Guid AvailableRoles { get; set; }
    /// <summary>
    /// Super role
    /// </summary>
    public bool IsSuper { get; set; }
}