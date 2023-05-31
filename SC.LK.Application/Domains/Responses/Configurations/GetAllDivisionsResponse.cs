using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Configurations;

public class GetAllDivisionsTerminalsResponse : BaseResponse
{
    public List<DivisionsTerminalsDtoRes> DtoRes { get; set; }
}

public class DivisionsTerminalsDtoRes
{
    public string DivisionName { get; set; }
    public Guid DivisionId { get; set; }
    public string TerminalName { get; set; }
    public Guid TerminalId { get; set; }
}