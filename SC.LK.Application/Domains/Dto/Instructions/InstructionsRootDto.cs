using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.RepositoryConfigurationService;

namespace SC.LK.Application.Domains.Dto;

public class InstructionsRootDto
{
    public Guid InstructionId { get; set; }

    public int Idx { get; set; }

    public string Value { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int InputData { get; set; }

    public string Group { get; set; }

    public List<InstructionsEventDto> Events { get; set; }

    public List<InstructionsParameterDto> Parameters { get; set; }

    public InstructionsSettingDto Setting { get; set; }
}