using SC.LK.Application.Domains.CloudApiService;

namespace SC.LK.Application.Abstractions;

public interface ICloudApiServiceAdaptor
{
    /// <summary>
    /// AuthHeader
    /// </summary>
    public string AuthHeader { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public   System.Threading.Tasks.Task<VersionResponse> VersionAsync(
        System.Threading.CancellationToken cancellationToken);

    /// <summary>
    /// Жизненый цикл агента, где находится
    /// </summary>
    /// <param name="body"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public   System.Threading.Tasks.Task AddLifeAgentAsync(LifeAgentNow body,
        System.Threading.CancellationToken cancellationToken);

    /// <summary>
    /// Получение привязки AgentId к контрагенту
    /// </summary>
    /// <param name="kontrAgentId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public   System.Threading.Tasks.Task<System.Collections.Generic.ICollection<ScannerDto>>
        BindingAgentIdTerminalIdAsync(System.Guid? kontrAgentId, System.Threading.CancellationToken cancellationToken);

    /// <summary>
    /// Получение последней доступности Агентов
    /// </summary>
    /// <param name="kontrAgentId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<AgentDto>> AgentsLiveAsync(
        System.Guid? kontrAgentId, System.Threading.CancellationToken cancellationToken);
    
    /// <summary>
    /// Регистрация агента из сборщика
    /// </summary>
    /// <param name="body"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public   System.Threading.Tasks.Task AddAgentAsync(LifeAgentNow body,
        System.Threading.CancellationToken cancellationToken);

    /// <summary>
    /// Регистрация сканера получение сертификата
    /// </summary>
    /// <param name="idSccanner"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public   System.Threading.Tasks.Task<string> AddScannerAsync(string idSccanner, System.Guid? body,
        System.Threading.CancellationToken cancellationToken);

    /// <summary>
    /// Получение конфигурации
    /// </summary>
    /// <param name="agentId"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public   System.Threading.Tasks.Task<ScannerDescription> GetConfigurationsAsync(System.Guid? agentId,
        int? body, System.Threading.CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает конфигурации те которых нет в кеше
    /// </summary>
    /// <param name="agentId"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public   System.Threading.Tasks.Task<System.Collections.Generic.ICollection<ScannerDescription>>
        GetConfigurationsForAgentAsync(System.Guid? agentId, System.Collections.Generic.IEnumerable<LocalCache> body,
            System.Threading.CancellationToken cancellationToken);
}