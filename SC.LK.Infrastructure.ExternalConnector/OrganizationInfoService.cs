using Microsoft.Extensions.Options;
using SC.LK.Application.Abstractions.ExternalConnectors;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.ExternalConnectors;
using SC.LK.Application.Extentions;
using SC.LK.Infrastructure.ExternalConnector.Adaptors;

namespace SC.LK.Infrastructure.ExternalConnector;

public class OrganizationInfoService: IOrganizationInfoService
{
    private readonly Dictionary<GetOrganizationByInnApiType, IGetOrganizationByInn> _adaptors;
    private readonly OrganizationServiceOptions _settings;
    
    public OrganizationInfoService(IOptions<OrganizationServiceOptions>? options)
    {
        _settings = options.Value;
        _adaptors = new Dictionary<GetOrganizationByInnApiType, IGetOrganizationByInn>()
        {
            {GetOrganizationByInnApiType.DaDataApi, new DaDataClient(_settings) },
            {GetOrganizationByInnApiType.FnsApi, new FNSClient(_settings) }
        };
    }

    public Task<InfoOrganization> GetInfo(string innNumber) =>
        _adaptors[_settings.Adapter.ToEnum<GetOrganizationByInnApiType>()].GetInnAsync(innNumber);
}