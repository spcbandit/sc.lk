using System.Runtime.Serialization;

namespace SC.LK.Application.Domains.Enums;

public enum GetOrganizationByInnApiType
{
    [EnumMember(Value = "DaData")]
    DaDataApi,
    [EnumMember(Value = "FnsApi")]
    FnsApi
}