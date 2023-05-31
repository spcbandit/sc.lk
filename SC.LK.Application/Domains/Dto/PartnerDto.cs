namespace SC.LK.Application.Domains.Dto;

public class PartnerDto: Domains.BaseDto
{
    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }
        
    /// <summary>
    /// Password
    /// </summary>
    public string? Password { get; set; }
        
    /// <summary>
    /// Token
    /// </summary>
    public string? Token { get; set; }
}