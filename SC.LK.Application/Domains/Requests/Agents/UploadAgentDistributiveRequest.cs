using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Domains.Requests.Agents;

public class UploadAgentDistributiveRequest:IRequest<UploadAgentDistributiveResponse>
{

    public IFormFile File { get; set; }
    // [Required]
    // public Guid AssetId { get; set; }
    // [Required]
    // public string SWType { get; set; }
    public string Version { get; set; }
    public string ChangeLog { get; set; }
    // [Required]
    // public int IsActive { get; set; }
}