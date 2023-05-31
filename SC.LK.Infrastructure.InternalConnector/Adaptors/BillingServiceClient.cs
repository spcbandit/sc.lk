using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.InternalConnectors;
using SC.LK.Application.Domains.InternalConnectors.BillingService;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SC.LK.Infrastructure.InternalConnector.Adaptors;

public class BillingServiceClient : IBillingServiceAdaptor
{
    private string _baseUrl = String.Empty;
    private BillingServiceOptions _settingsClientOptions;
    private readonly RestClient _client;
        
    /// <summary>
    /// RCClient
    /// </summary>
    /// <param name="options"></param>
    public BillingServiceClient(IOptions<BillingServiceOptions> options)
    {
        _settingsClientOptions = options.Value;
        _baseUrl = _settingsClientOptions.BaseUrl;
        _client = new RestClient(_baseUrl);
    }

    /// <summary>
    /// AuthHeader
    /// </summary>
    public string AuthHeader { get; set; }

    #region Info
    public async Task<VersionResponse> VersionAsync()
    {
        string resource = "Version";
        var request = CreateRequest(resource, Method.GET, null);
        var response = await GetResponse<VersionResponse>(request:request);
        return response;
    }
    #endregion
    #region ItemForSale

    public async Task<ItemForSaleResponse> AddItemForSale(ItemForSaleResponse body)
    {
        string resurce = $"ItemForSale/addItemForSale";
        var request = CreateRequest(resurce, Method.POST, body);
        var response = await GetResponse<ItemForSaleResponse>(request:request);
        return response;
    }
    public async Task<ItemForSaleResponse> UpdateItemForSale(Guid id, ItemForSaleResponse body)
    {
        string resurce = $"ItemForSale/updateItemForSale/{id}";
        var request = CreateRequest(resurce, Method.PUT, body);
        var response = await GetResponse<ItemForSaleResponse>(request:request);
        return response;
    }
    public async Task<ItemForSaleResponse> GetItemForSaleByItemForSaleId(Guid id)
    {
        string resurce = $"ItemForSale/getItemForSaleByItemForSaleId?itemForSaleId={id}";
        var request = CreateRequest(resurce, Method.GET, null);
        var response = await GetResponse<ItemForSaleResponse>(request:request);
        return response;
    }
    public async Task<ActionResult> DeleteItemForSale(Guid id)
    {
        string resurce = $"ItemForSale/delete/{id}";
        var request = CreateRequest(resurce, Method.DELETE, id);
        var response = await GetResponse<ActionResult>(request:request);
        return response;
    }
    public async Task<List<ItemForSaleResponse>> GetAllItemForSale()
    {
        string resurce = $"ItemForSale/getAllItemForSale";
        var request = CreateRequest(resurce, Method.GET, null);
        var response = await GetResponse<List<ItemForSaleResponse>>(request:request);
        return response;
    }

    #endregion
    #region License
       public async Task<Guid> AddLicenseAsync(LicenseView body)
    {
        string resurce = "License/addLicense";
        var request = CreateRequest(resurce, Method.POST, body);
        var response = await GetResponse<Guid>(request:request);
        return response;
    }

    public async Task<Guid> UpdateLicenseAsync(Guid licenseId, LicenseView body)
    {
        string resurce = $"License/updateLicense/{licenseId}";
        var request = CreateRequest(resurce, Method.PUT, body);
        var response = await GetResponse<Guid>(request:request);
        return response;
    }

    public async Task<LicenseView> GetLicenseByIdAsync(Guid? licenseId)
    {
        string resurce = $"License/getLicenseById?licenseId={licenseId}";
        var request = CreateRequest(resurce, Method.GET, null);
        var response = await GetResponse<LicenseView>(request:request);
        return response;
    }

    public async Task<Guid> DeactivateLicenseAsync(Guid licenseId)
    {
        string resurce = $"License/deactivateLicense/{licenseId}";
        var request = CreateRequest(resurce, Method.DELETE, null);
        var response = await GetResponse<Guid>(request: request);
        return response;
    }

    public async Task<List<LicenseView>> GetLicencesByKontragentAsync(Guid? kontragentId)
    {
        string resurce = $"License/getLicencesByKontragent?kontragentId={kontragentId}";
        var request = CreateRequest(resurce, Method.GET, null);
        var response = await GetResponse<List<LicenseView>>(request: request);
        return response;
    }

    public async Task<bool> BindLicenceToTerminalAsync(LicenceTerminalView body)
    {
        string resurce = $"License/bindLicenceToTerminal";
        var request = CreateRequest(resurce, Method.POST, body);
        var response = await GetResponse(request: request);
        return response;
    }

    public async Task<bool> ReleaseLicenceAsync(LicenceTerminalView body)
    {
        string resurce = $"License/releaseLicence";
        var request = CreateRequest(resurce, Method.POST, body);
        var response = await GetResponse(request: request, true);
        return response is HttpStatusCode.NotFound or HttpStatusCode.OK;
    }

    public async Task<bool> DeleteTerminalAsync(Guid? licenseId, string updatedBy)
    {
        string resurce = $"License/deleteTerminal?licenseId={licenseId}&updatedBy={updatedBy}";
        var request = CreateRequest(resurce, Method.GET, null);
        var response = await GetResponse(request: request);
        return response;
    }
    

    #endregion
    #region PriceList
    public async Task<PriceListResponse> AddPriceList(PriceListResponse body)
    {
        string resurce = $"PriceList/addPriceList";
        var request = CreateRequest(resurce, Method.POST, body);
        var response = await GetResponse<PriceListResponse>(request:request);
        return response;
    }
    public async Task<PriceListResponse> UpdatePriceList(Guid id, PriceListResponse body)
    {
        string resurce = $"PriceList/updatePriceList/{id}";
        var request = CreateRequest(resurce, Method.PUT, body);
        var response = await GetResponse<PriceListResponse>(request:request);
        return response;
    }
    public async Task<ItemForSaleResponse> GetPriceListByPriceListId(Guid id)
    {
        string resurce = $"PriceList/getPriceListByPriceListId?priceListId={id}";
        var request = CreateRequest(resurce, Method.GET, null);
        var response = await GetResponse<ItemForSaleResponse>(request:request);
        return response;
    }
    public async Task<ActionResult> DeletePriceList(Guid id)
    {
        string resurce = $"PriceList/delete/{id}";
        var request = CreateRequest(resurce, Method.DELETE, id);
        var response = await GetResponse<ActionResult>(request:request);
        return response;
    }
    

    #endregion
    #region PriceListBody

    public async Task<PriceListBodyes> AddPriceListBody(PriceListBodyes body)
    {
        string resurce = $"PriceListBody/addPriceListBody";
        var request = CreateRequest(resurce, Method.POST, body);
        var response = await GetResponse<PriceListBodyes>(request:request);
        return response;
    }
    public async Task<PriceListBodyes> UpdatePriceListBody(Guid id, PriceListBodyes body)
    {
        string resurce = $"PriceListBody/updatePriceListBody/{id}";
        var request = CreateRequest(resurce, Method.PUT, body);
        var response = await GetResponse<PriceListBodyes>(request:request);
        return response;
    }
    public async Task<PriceListBodyes> GetPriceListByPriceListBodyId(Guid id)
    {
        string resurce = $"PriceListBody/getPriceListBodyByPriceListBodyId?priceListBodyId={id}";
        var request = CreateRequest(resurce, Method.GET, null);
        var response = await GetResponse<PriceListBodyes>(request:request);
        return response;
    }
    public async Task<ActionResult> DeletePriceListBody(Guid id)
    {
        string resurce = $"PriceListBody/delete/{id}";
        var request = CreateRequest(resurce, Method.DELETE, id);
        var response = await GetResponse<ActionResult>(request:request);
        return response;
    }
    #endregion
    #region PriceListHeader

    public async Task<PriceListHeader> AddPriceListHeader(PriceListHeader body)
    {
        string resurce = $"PriceListHeader/addPriceListHeader";
        var request = CreateRequest(resurce, Method.POST, body);
        var response = await GetResponse<PriceListHeader>(request:request);
        return response;
    }
    public async Task<PriceListHeader> UpdatePriceListHeader(Guid id, PriceListHeader body)
    {
        string resurce = $"PriceListHeader/updatePriceListHeader/{id}";
        var request = CreateRequest(resurce, Method.PUT, body);
        var response = await GetResponse<PriceListHeader>(request:request);
        return response;
    }
    public async Task<PriceListHeader> GetPriceListHeaderByPriceListHeaderId(Guid id)
    {
        string resurce = $"PriceListHeader/getPriceListHeaderByPriceListHeaderId?priceListHeaderId={id}";
        var request = CreateRequest(resurce, Method.GET, null);
        var response = await GetResponse<PriceListHeader>(request:request);
        return response;
    }
    public async Task<ActionResult> DeletePriceListHeader(Guid id)
    {
        string resurce = $"PriceListHeader/delete/{id}";
        var request = CreateRequest(resurce, Method.DELETE, id);
        var response = await GetResponse<ActionResult>(request:request);
        return response;
    }
    

    #endregion
    #region Update
    public async Task<ActionResult> DeactivateAllLicensesByKontragentId(Guid id)
    {
        string resurce = $"Update/deactivateAllLicencesByKontragent?kontragentId={id}";
        var request = CreateRequest(resurce, Method.GET, null);
        var response = await GetResponse<ActionResult>(request:request);
        return response;
    }
    #endregion
    /// <summary>
    /// Создание реквеста
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="method"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    private IRestRequest CreateRequest(string resource, Method method, object? body)
    {
        var request = new RestRequest(resource, method) {RequestFormat = DataFormat.Json};
        _client.Authenticator = new JwtAuthenticator(this.AuthHeader);

        request.AddJsonBody(body);
        return request;
    }

    /// <summary>
    /// Обработка респонса
    /// </summary>
    /// <param name="request"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private async Task<T> GetResponse<T>(IRestRequest request)
    {
        var response = await _client.ExecuteAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return JsonConvert.DeserializeObject<T>("{}");
        }
        else if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            return JsonConvert.DeserializeObject<T>("{}");
        }
        else if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return JsonConvert.DeserializeObject<T>("{}");
        }

        throw new Exception(JsonSerializer.Serialize(new {Response = response.Content, Request = request}));
    }

    /// <summary>
    /// Обработка респонса
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private async Task<bool> GetResponse(IRestRequest request)
    {
        var response = await _client.ExecuteAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return true;
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return false;
        }
        else if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            return false;
        }
        else if(response.StatusCode == HttpStatusCode.BadRequest)
        {
            return false;
        }

        throw new Exception(JsonSerializer.Serialize(new {Response = response.Content, Request = request}));
    }
    /// <summary>
    /// Обработка респонса
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private async Task<HttpStatusCode> GetResponse(IRestRequest request, bool onlyStatus)
    {
        var response = await _client.ExecuteAsync(request);
        return response.StatusCode;

        throw new Exception(JsonSerializer.Serialize(new {Response = response.Content, Request = request}));
    }
}