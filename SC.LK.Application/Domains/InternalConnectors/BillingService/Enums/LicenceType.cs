using System.Runtime.Serialization;

namespace SC.LK.Application.Domains.InternalConnectors.BillingService.Enums;

public enum LicenceType
{
    [EnumMember(Value = "Year")]
    Year = 0,
    [EnumMember(Value = "Live")]
    Live = 1
}