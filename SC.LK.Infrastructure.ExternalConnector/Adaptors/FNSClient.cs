using System.Net.Http.Headers;
using SC.LK.Application.Abstractions.ExternalConnectors;
using SC.LK.Application.Domains.ExternalConnectors;
using SC.LK.Application.Domains.ExternalConnectors.FNSService;

namespace SC.LK.Infrastructure.ExternalConnector.Adaptors;

public class FNSClient: IGetOrganizationByInn
{
    private string _baseUrl = "";
    private string _token = "";
    private System.Net.Http.HttpClient _httpClient;
    private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

    /// <summary>
    /// Получение головной организации по ИНН 
    /// </summary>
    public FNSClient(OrganizationServiceOptions settings)
    {
        _token = settings.Token;
        _baseUrl = settings.BaseUrl;
        _httpClient = new HttpClient() { BaseAddress = new Uri(_baseUrl) };
    }

    /// <summary>
    /// Получение головной организации по ИНН 
    /// </summary>
    /// <param name="Inn"></param>
    /// <param name="INN"></param>
    /// <returns></returns>
    public async Task<InfoOrganization> GetInnAsync(string Inn)
    {
        if (Inn.Trim().Length == 10)
        {
            var egrDto = new EGRDto(new List<Items>());
            var urlBuilder_ = $"{_baseUrl}egr?req={Inn}&key={_token}";
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = await _httpClient.GetAsync(urlBuilder_);
            
            if (response.IsSuccessStatusCode)
            {
                egrDto = await response.Content.ReadAsAsync<EGRDto>();
            }

            if (egrDto != null)
            {
                return new InfoOrganization()
                {
                    ContractorName = egrDto.ItemsList[0].LegalEntity.OrganizationName,
                    INN = egrDto.ItemsList[0].LegalEntity.INN,
                    KPP = egrDto.ItemsList[0].LegalEntity.KPP,
                };
            }
            else
            {
                return null;
            }
        }
        else if (Inn.Trim().Length == 12)
        {
            var searchDto = new SearchDto(new List<SearchDtoItem>());
            var urlBuilder_ = $"{_baseUrl}search?q={Inn}&key={_token}";
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = await _httpClient.GetAsync(urlBuilder_);
            
            if (response.IsSuccessStatusCode)
            {
                searchDto = await response.Content.ReadAsAsync<SearchDto>();
            }

            if (searchDto != null)
            {
                return new InfoOrganization()
                {
                    ContractorName = searchDto.Items.FirstOrDefault(x=>x.IndividualEntrepreneur != null).IndividualEntrepreneur.FIO,
                    INN = searchDto.Items.FirstOrDefault(x=>x.IndividualEntrepreneur != null).IndividualEntrepreneur.Inn,
                    KPP = null,
                };
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}