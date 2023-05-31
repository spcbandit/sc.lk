using MediatR;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.Requests.Profile;

public class ChangeDataRequest : IRequest<ChangeDataResponse>
{
    /// <summary>
    /// ID
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// FIO
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// FIO
    /// </summary>
    public string Parent { get; set; }
    
    /// <summary>
    /// FIO
    /// </summary>
    public string Family { get; set; }
    
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
}