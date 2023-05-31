namespace SC.LK.Application.Domains.Responses.Market;

public class GetTemplatesByContragentResponse:BaseResponse
{
    public List<Guid?> TemplatesList { get; set; }
}