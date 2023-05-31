using SC.LK.Application.Domains.SigningEncryptionService;

namespace SC.LK.Application.Abstractions;

public interface ISigningEncryptionAdaptor
{
    /// <summary>
    /// AuthHeader
    /// </summary>
    public string AuthHeader { get; set; }
    /// <summary>
    /// Получение сертификата для сканера
    /// </summary>

    /// <param name="scannerId">Id терминала из БД</param>

    /// <returns>Тело сертификата</returns>

    System.Threading.Tasks.Task<string> GetCurrentCertificateAsync(System.Guid? scannerId);

    /// <summary>
    /// Регистрация нового сканера
    /// </summary>

    /// <param name="body">id торговой сети</param>

    /// <returns>Success</returns>

    System.Threading.Tasks.Task<ClientView> RegisterClientAsync(string body);

    /// <summary>
    /// Подписывание файлов
    /// </summary>

    /// <param name="scanerId">Чем подписываем</param>

    /// <param name="body">Что подпичсываем</param>

    /// <returns>Success</returns>

    System.Threading.Tasks.Task<string> SigningAsync(System.Guid? scanerId, string body);

    /// <summary>
    /// Регистрация сертификата контрагента
    /// </summary>

    /// <param name="kontragentId">id контрагента</param>

    /// <returns>Успешно зарегистрирован</returns>

    System.Threading.Tasks.Task<bool> GenerateCertificateKontragentAsync(System.Guid kontragentId);

    /// <summary>
    /// Получение сертификата для контрагента
    /// </summary>

    /// <param name="kontragentId">Id контрагента</param>

    /// <returns>Тело сертификата</returns>

    System.Threading.Tasks.Task<KontragentCertificateView> GetKontragentCertificateAsync(System.Guid? kontragentId);

    /// <summary>
    /// Подписывание файлов
    /// </summary>

    /// <param name="body">Что подпичсываем</param>

    /// <returns>Подписанный файл</returns>

    System.Threading.Tasks.Task<SignedKontragentFileView> SigningKontragentAsync(SignKontragentFileView body);

}