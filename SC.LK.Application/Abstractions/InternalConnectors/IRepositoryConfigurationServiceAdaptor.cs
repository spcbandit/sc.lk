using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Requests.DistributivesVersions;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Agents;
using SC.LK.Application.Domains.Responses.DistributivesVersions;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Abstractions;

public partial interface IRepositoryConfigurationServiceAdaptor
    {
        /// <summary>
        /// AuthHeader
        /// </summary>
        public string AuthHeader { get; set; }
        
        /// <summary>
        /// Сохранение агента
        /// </summary>
        /// <returns>Id созданного агента</returns>
        Task<System.Guid> AddAgentAsync(AgentView body);

        /// <summary>
        /// Обновление агента
        /// </summary>
        /// <param name="agentId">Id агента</param>
        /// <param name="body">Агент</param>
        /// <returns>Ok</returns>
        Task<System.Guid> UpdateAgentAsync(System.Guid agentId, AgentView body);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kontrAgentId"></param>
        /// <returns></returns>
        Task<AgentsView> GetAgentsByKontragentId(Guid? kontrAgentId);
        
        /// <summary>
        /// Получение расширенного массива агентов по массиву AgentID
        /// </summary>
        /// <returns>Агенты</returns>
        Task<AgentsViewExtended> GetAgentsByAgentsIdExtendedAsync(AgentsView body);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="divisionId"></param>
        /// <returns></returns>
        Task<AgentsView> GetAgentsByDivisionId(Guid? divisionId);

        /// <summary>
        /// Получение дистрибутива
        /// </summary>
        /// <returns>Дистрибутив</returns>
        Task<FileStreamResult> GetDistributiveAgentAsync();
        
        /// <summary>
        /// Получение агента по agentId
        /// </summary>
        /// <param name="agentId">AgentId</param>
        /// <returns>Конфигурация</returns>
        Task<AgentView> GetAgentByAgentIdAsync(System.Guid? agentId);

        /// <summary>
        /// Получение терминалов агента по agentId
        /// </summary>
        /// <param name="agentId">AgentId</param>
        /// <returns>Терминалы</returns>
        Task<ManagedTerminalsView> GetManagedTerminalsIdsAsync(System.Guid? agentId);

        /// <summary>
        /// Проверка версии для agentId
        /// </summary>
        /// <param name="agentId">AgentId</param>
        /// <param name="version">version</param>
        /// <returns>Версии равны</returns>
        Task CheckForUpdateAsync(System.Guid? agentId, string version);

        /// <summary>
        /// Получение дистрибутива для agentId
        /// </summary>
        /// <param name="agentId">AgentId</param>
        /// <param name="version">version</param>
        /// <returns>Дистрибутив</returns>
        Task GetUpdateAsync(System.Guid? agentId, string version);
        
        /// <summary>
        /// Сохранение процесса
        /// </summary>
        /// <returns>Id созданного процесса</returns>
        Task<System.Guid> AddBusinessProcessAsync(BusinessProcessView body);

        /// <summary>
        /// Обновление процесса
        /// </summary>
        /// <param name="businessProcessId">Id процесса</param>
        /// <param name="body">Процесс</param>
        /// <returns>Ok</returns>
        Task<System.Guid> UpdateBusinessProcessAsync(System.Guid businessProcessId, BusinessProcessView body);

        /// <summary>
        /// Получение процесса по kontragentId
        /// </summary>
        /// <param name="kontragentId">KontragentId</param>
        /// <returns>Процессы</returns>
        Task<List<BusinessProcessWithOutJsonBodyView>> GetBusinessProcessByKontragentIdAsync(System.Guid? kontragentId);

        /// <summary>
        /// Получение JsonBody по businessProcessId
        /// </summary>
        /// <param name="businessProcessId">businessProcessId</param>
        /// <returns>JsonBody</returns>
        Task<BusinessProcessView> GetBusinessProcessByBusinessProcessIdAsync(System.Guid? businessProcessId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessProcessId"></param>
        /// <returns></returns>
        Task<bool> DeleteBusinessProcessByBusinessProcessIdAsync(Guid? businessProcessId);
        
        /// <summary>
        /// Сохранение конфигурации
        /// </summary>
        /// <returns>Id созданной конфигурации</returns>
        Task<System.Guid> AddConfigurationAsync(ConfigurationView body);

        /// <summary>
        /// Обновление конфигурации
        /// </summary>
        /// <param name="configurationId">Id конфигурации</param>
        /// <param name="body">Конфигурация</param>
        /// <returns>Ok</returns>
        Task<System.Guid> UpdateConfigurationAsync(System.Guid configurationId, ConfigurationView body);

        /// <summary>
        /// Получение конфигурации по kontragentId
        /// </summary>
        /// <param name="kontragentId">KontragentId</param>
        /// <returns>Конфигурация</returns>
        Task<System.Collections.Generic.List<ConfigurationView>> GetConfigurationByKontragentIdAsync(System.Guid? kontragentId);

        /// <summary>
        /// Сохранение версии конфигурации
        /// </summary>
        /// <returns>Id созданной версии конфигурации</returns>
        Task<System.Guid> AddConfigurationVersionAsync(ConfigurationVersionView body);

        /// <summary>
        /// Обновление версии конфигурации
        /// </summary>
        /// <param name="configurationVersionId">Id версии конфигурации</param>
        /// <param name="body">Версия конфигурации</param>
        /// <returns>Ok</returns>
        Task<System.Guid> UpdateConfigurationVersionAsync(System.Guid configurationVersionId, ConfigurationVersionView body);

        /// <summary>
        /// Активация версии конфигурации
        /// </summary>
        /// <param name="configurationVersionId">Id версии конфигурации</param>
        /// <returns>Ok</returns>
        Task<System.Guid> ActivateConfigurationVersionAsync(System.Guid configurationVersionId);

        /// <summary>
        /// Получение версий конфигурации по ConfigurationId
        /// </summary>
        /// <param name="configurationId">ConfigurationId</param>
        /// <returns>Версии конфигурации</returns>
        Task<List<ConfigurationVersionView>> GetConfigurationVersionsByConfigurationIdAsync(System.Guid? configurationId);

        /// <summary>
        /// Получение версии конфигурации по configurationVersionId
        /// </summary>
        /// <param name="configurationVersionId">configurationVersionId</param>
        /// <returns>Версия конфигурации</returns>
        Task<ConfigurationVersionView> GetConfigurationVersionByConfigurationVersionIdAsync(System.Guid? configurationVersionId);

        /// <summary>
        /// Удаление версии конфигурации
        /// </summary>
        /// <param name="ConfigurationId"></param>
        /// <returns></returns>
        Task<bool> DeleteConfigurationVersionByVersionIdAsync(Guid? ConfigurationVersionId);
        
        /// <summary>
        /// Сохранение терминала
        /// </summary>
        /// <returns>Id созданного терминала</returns>
        Task<System.Guid> AddTerminalAsync(TerminalView body);

        /// <summary>
        /// Обновление терминала
        /// </summary>
        /// <param name="terminalId">Id терминала</param>
        /// <param name="body">Терминал</param>
        /// <returns>Ok</returns>
        Task<System.Guid> UpdateTerminalAsync(System.Guid terminalId, TerminalView body);

        /// <summary>
        /// Получение терминала по terminalId
        /// </summary>
        /// <param name="terminalId">terminalId</param>
        /// <returns>Конфигурация</returns>
        Task<TerminalView> GetTerminalByTerminalIdAsync(System.Guid? terminalId);

        /// <summary>
        /// Удаление терминала
        /// </summary>
        /// <param name="terminalId">Id терминала</param>
        /// <param name="updateBy">Кто удалил</param>
        /// <returns>Ok</returns>
        Task<System.Guid> DeleteAsync(System.Guid terminalId, string updateBy);

        /// <summary>
        /// Получение версии конфигурации по terminalId
        /// </summary>
        /// <param name="terminalId">terminalId</param>
        /// <returns>ConfigurationVersionSignView</returns>
        Task<ConfigurationVersionSignView> GetConfigurationVervionByTerminalIdAsync(System.Guid? terminalId);

        /// <summary>
        /// Получение терминалов по divisionId
        /// </summary>
        /// <param name="terminalId">terminalId</param>
        /// <returns>ConfigurationVersionSignView</returns>
        Task<ManagedTerminalsViewExtended> GetTerminalsByDivisionIdAsync(Guid? divisionId);

        /// <summary>
        /// Получение терминалов по kontragentId
        /// </summary>
        /// <param name="kontragentId"></param>
        /// <returns></returns>
        Task<ManagedTerminalsViewExtended> GetTerminalsByKontragentIdAsync(Guid? kontragentId);
        
        /// <summary>
        /// Проверка версии для terminalId
        /// </summary>
        /// <param name="terminalId">terminalId</param>
        /// <param name="version">version</param>
        /// <returns>Версии равны</returns>
        Task CheckForUpdate2Async(System.Guid? terminalId, string version);

        /// <summary>
        /// Получение дистрибутива для terminalId
        /// </summary>
        /// <param name="terminalId">terminalId</param>
        /// <param name="version">version</param>
        /// <returns>Дистрибутив</returns>
        Task GetUpdate2Async(System.Guid? terminalId, string version);
        
        /// <summary>
        /// Получение дистрибутива для terminalId
        /// </summary>
        /// <returns>Дистрибутив</returns>
        Task<string> GetDistributiveTerminalAsync();
        
        /// <summary>
        /// Добавление лицензии для терминала
        /// </summary>
        /// <param name="body">LicenceTerminalView</param>
        /// <returns>Ok</returns>
        Task<bool> AssignLicenceToTerminalAsync(LicenceTerminalView body);

        /// <summary>
        /// Освобождение лицензии для терминала
        /// </summary>
        /// <param name="body">LicenceTerminalView</param>
        /// <returns>Ok</returns>
        Task<bool> ReleaseLicenceFromTerminalAsync(LicenceTerminalView body);
        /// <summary>
        /// Получение полной конфигурации
        /// </summary>
        /// <returns></returns>
        Task<string> GetFullConfig();
        /// <summary>
        /// Добавить инструкцию
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<Guid> AddInstruction(InstructionsRootView body);
        /// <summary>
        /// Обновить инструкцию
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<Guid> UpdateInstructions(InstructionsRootView body);
        /// <summary>
        /// Получить инструкцию по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<InstructionsRootView> GetInstructionsByInstructionsId(Guid id);
        /// <summary>
        /// Удалить инструкцию
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Guid> DeleteInstruction(Guid id);
        /// <summary>
        /// Добавить параметр
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<Guid> AddParameters(InstructionsParameterView body);
        /// <summary>
        /// Обновить параметр
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<Guid> UpdateParameters(InstructionsParameterView body);
        /// <summary>
        /// Получить параметр по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<InstructionsParameterView> GetParametersByParameterId(Guid id);
        /// <summary>
        /// Удалить параметр
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Guid> DeleteParameters(Guid id);
        /// <summary>
        /// Добавить значение параметра
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<Guid> AddParametersValues(InstructionsParametersValueView body);
        /// <summary>
        /// Обновить значение параметра
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<Guid> UpdateParametersValues(InstructionsParametersValueView body);
        /// <summary>
        /// Получить значения параметра по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<InstructionsParametersValueView> GetParametersValuesByParameterValuesId(Guid id);
        /// <summary>
        /// Удалить значения параметра
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Guid> DeleteParametersValues(Guid id);
        /// <summary>
        /// Загрузить дистрибутив терминала
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<UploadTerminalDistributiveResponse> UploadTerminalDistributive(UploadTerminalDistributiveRequest body);
        /// <summary>
        /// Загрузить дистрибутив агента
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>

        Task<UploadAgentDistributiveResponse> UploadAgentDistributive(UploadAgentDistributiveRequest body);
        /// <summary>
        /// GetDistributive
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<DistributivesView> GetAgentDistributiveVersion(GetDistributivesVersionsRequest body);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<DistributivesView> GetTerminalDistributiveVersion(GetDistributivesVersionsRequest body);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<List<Guid?>> GetAllTemplatesByContragentId(Guid body);
    Task<bool> DeleteAgentByAgentId(Guid agentId);
}
