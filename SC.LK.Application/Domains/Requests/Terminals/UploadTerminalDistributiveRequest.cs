using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Domains.Requests.Terminals;

public class UploadTerminalDistributiveRequest:IRequest<UploadTerminalDistributiveResponse>
{
    [Required]
    public string Link { get; set; }
    // [Required]
    // public Guid AssetId { get; set; }
    // [Required]
    // public string SWType { get; set; }
    [Required]
    public string Version { get; set; }
    [Required]
    public string ChangeLog { get; set; }
    // [Required]
    // public int IsActive { get; set; }
}