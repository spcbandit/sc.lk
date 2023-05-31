using System.Runtime.Serialization;

namespace SC.LK.Application.Domains.Enums;

public enum ContractorType
{
    [EnumMember(Value = "Client")]
    Client   = 0,
    [EnumMember(Value = "Partner")]
    Partner  = 1,
    [EnumMember(Value = "Provider")]
    Provider = 2
}