using System.Runtime.Serialization;

namespace SC.LK.Application.Domains.Enums;

public enum ContractorStatusType
{
    [EnumMember(Value = "New")]
    New                    = 0,
    [EnumMember(Value = "Confirmed")]
    Confirmed              = 1,
    [EnumMember(Value = "ConfirmedStatusPartner")]
    ConfirmedStatusPartner = 2,
    [EnumMember(Value = "Active")]
    Active                 = 3,
    [EnumMember(Value = "Paused")]
    Paused                 = 4
}