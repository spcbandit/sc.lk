using SC.LK.Application.Domains.ExternalConnectors;

namespace SC.LK.Application.Abstractions.ExternalConnectors;

public interface IGetOrganizationByInn
{
    /// <summary>
    /// Получение головной организации по ИНН 
    /// </summary>
    /// <param name="Inn"></param>
    /// <param name="INN"></param>
    /// <returns></returns>
    public Task<InfoOrganization> GetInnAsync(string Inn);
}