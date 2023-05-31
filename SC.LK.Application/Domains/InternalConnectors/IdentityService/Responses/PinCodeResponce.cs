namespace SC.LK.Application.Domains.InternalConnectors.IdentityService.Responses;

public class PinCodeResponce
{
    /// <summary>
    /// KontrAgent
    /// </summary>
    public Guid KontrAgent { get; set; } 
    
    /// <summary>
    /// PinCode
    /// </summary>
    public int PinCode { get; set; }
}