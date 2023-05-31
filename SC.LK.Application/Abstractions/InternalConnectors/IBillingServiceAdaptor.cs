using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.InternalConnectors;
using SC.LK.Application.Domains.InternalConnectors.BillingService;
using SC.LK.Application.Domains.RepositoryConfigurationService;

namespace SC.LK.Application.Abstractions;

public interface IBillingServiceAdaptor
{
    /// <summary>
    /// AuthHeader
    /// </summary>
    public string AuthHeader { get; set; }

    #region Info

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<VersionResponse> VersionAsync();

    #endregion
    #region ItemForSale

    public Task<ItemForSaleResponse> AddItemForSale(ItemForSaleResponse body);

    public Task<ItemForSaleResponse> UpdateItemForSale(Guid id, ItemForSaleResponse body);

    public Task <ItemForSaleResponse> GetItemForSaleByItemForSaleId(Guid id);

    public Task<ActionResult> DeleteItemForSale(Guid id);

    public Task<List<ItemForSaleResponse>> GetAllItemForSale();

    #endregion
    #region License

    /// <summary>
    /// Сохранение лицензии
    /// </summary>
    /// <returns>Id созданной лицензии</returns>
    Task<Guid> AddLicenseAsync(LicenseView body);

    /// <summary>
    /// Обновление лицензии
    /// </summary>
    /// <param name="licenseId">Id лицензии</param>
    /// <param name="body">Лицензия</param>
    /// <returns>Ok</returns>
    Task<Guid> UpdateLicenseAsync(Guid licenseId, LicenseView body);

    /// <summary>
    /// Получение лицензии по licenseId
    /// </summary>
    /// <param name="licenseId">licenseId</param>
    /// <returns>Лицензия</returns>
    Task<LicenseView> GetLicenseByIdAsync(Guid? licenseId);

    /// <summary>
    /// Удаление лицензии
    /// </summary>
    /// <param name="licenseId">Id лицензии</param>
    /// <returns>Ok</returns>
    Task<Guid> DeactivateLicenseAsync(Guid licenseId);

    /// <summary>
    /// Получение лицензий по kontragentId
    /// </summary>
    /// <param name="kontragentId">kontragentId</param>
    /// <returns>Лицензии</returns>
    Task<List<LicenseView>> GetLicencesByKontragentAsync(Guid? kontragentId);

    /// <summary>
    /// Присвоение лицензии для терминала
    /// </summary>
    Task<bool> BindLicenceToTerminalAsync(LicenceTerminalView body);

    /// <summary>
    /// Освобождение лицензии для терминала
    /// </summary>
    Task<bool> ReleaseLicenceAsync(LicenceTerminalView body);

    /// <summary>
    /// Освобождение лицензии от терминала
    /// </summary>
    /// <param name="licenseId">licenseId</param>
    /// <param name="updatedBy">updatedBy</param>
    Task<bool> DeleteTerminalAsync(Guid? licenseId, string updatedBy);

    #endregion
    #region PriceList

    public Task<PriceListResponse> AddPriceList(PriceListResponse body);

    public Task<PriceListResponse> UpdatePriceList(Guid id, PriceListResponse body);

    public Task<ItemForSaleResponse> GetPriceListByPriceListId(Guid id);

    public Task<ActionResult> DeletePriceList(Guid id);



    #endregion
    #region PriceListBody

    public Task<PriceListBodyes> AddPriceListBody(PriceListBodyes body);

    public Task<PriceListBodyes> UpdatePriceListBody(Guid id, PriceListBodyes body);

    public Task<PriceListBodyes> GetPriceListByPriceListBodyId(Guid id);

    public Task<ActionResult> DeletePriceListBody(Guid id);

    #endregion
    #region PriceListHeader

    public Task<PriceListHeader> AddPriceListHeader(PriceListHeader body);

    public Task<PriceListHeader> UpdatePriceListHeader(Guid id, PriceListHeader body);

    public Task<PriceListHeader> GetPriceListHeaderByPriceListHeaderId(Guid id);

    public Task<ActionResult> DeletePriceListHeader(Guid id);

    #endregion
    #region Update

    public Task<ActionResult> DeactivateAllLicensesByKontragentId(Guid id);

    #endregion
}