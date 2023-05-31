using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Templates;

public class CreateTemplatesResponse : BaseResponse
{
    /// <summary>
    /// Contractor
    /// </summary>
    public ContractorDto Contractor { get; set; }
}