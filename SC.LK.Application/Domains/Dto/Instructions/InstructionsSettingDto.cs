using SC.LK.Application.Domains.Dto.BaseDto;

namespace SC.LK.Application.Domains.Dto;

public class InstructionsSettingDto
{
    public Guid SettingsId { get; set; }

    public Guid InstructionId { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public string Instruction { get; set; }
}