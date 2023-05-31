using System.Runtime.Serialization;

namespace SC.LK.Application.Domains.ConfiguratorDispatcher.Enums;

public enum ElementType
{
    [EnumMember(Value = "layout")]
    Layout = 0,
    [EnumMember(Value = "label")]
    Label = 1,
    [EnumMember(Value = "separator")]
    Separator = 2,
    [EnumMember(Value = "button")]
    Button = 3
}