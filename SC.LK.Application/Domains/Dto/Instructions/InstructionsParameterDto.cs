using SC.LK.Application.Domains.Dto.BaseDto;

namespace SC.LK.Application.Domains.Dto;

public class InstructionsParameterDto
{
    public Guid ParameterId { get; set; }

    public Guid InstructionId { get; set; }

    public int Idx { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Type { get; set; }

    public Guid ParentId { get; set; }

    public List<InstructionsParametersValueDto> ParametersValues { get; set; }
}