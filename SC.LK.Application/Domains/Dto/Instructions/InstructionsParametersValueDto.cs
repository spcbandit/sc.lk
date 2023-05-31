namespace SC.LK.Application.Domains.Dto;

public class InstructionsParametersValueDto
{
    public Guid ValueId { get; set; }

    public Guid ParameterId { get; set; }

    public string Value { get; set; }

    public string Description { get; set; }

    public Guid ParentId { get; set; }
}