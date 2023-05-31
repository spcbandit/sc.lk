using System.Net.Http.Headers;
using Newtonsoft.Json;
using SC.LK.Application.Abstractions.ExternalConnectors;
using SC.LK.Application.Domains.ExternalConnectors;
using SC.LK.Application.Domains.ExternalConnectors.DaDataService;

namespace SC.LK.Infrastructure.ExternalConnector.Adaptors;

public class DaDataClient: IGetOrganizationByInn
{
    private string _baseUrl = "";
    private string _token = "";

    /// <summary>
    /// Получение головной организации по ИНН 
    /// </summary>
    public DaDataClient(OrganizationServiceOptions settings)
    {
        _token = settings.Token;
        _baseUrl = settings.BaseUrl;
    }

    /// <summary>
    /// Получение головной организации по ИНН 
    /// </summary>
    /// <param name="Inn"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<InfoOrganization> GetInnAsync(string Inn)
    {
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"),
                       $"{_baseUrl}findById/party"))
            {
                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("Authorization", _token);

                request.Content = new StringContent("{ \"query\": \""+ Inn +"\" }");
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var response = await httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrganizatioByINNDto>(content);
                var value = result.Suggestions.Where(x => x.Data.BranchType == "MAIN").FirstOrDefault();
                if(value != null)
                return new InfoOrganization()
                {
                    ContractorName = value.Value,
                    INN = value.Data.Inn,
                    KPP = value.Data.Kpp,
                };
                else
                {
                    return null;
                }
            }
        }
    }
}