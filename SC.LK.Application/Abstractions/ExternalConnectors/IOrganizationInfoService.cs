using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.ExternalConnectors;

namespace SC.LK.Application.Abstractions.ExternalConnectors;

public interface IOrganizationInfoService
{
    public Task<InfoOrganization> GetInfo(string innNumber);
}