using System.ComponentModel;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using Newtonsoft.Json;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Requests.DistributivesVersions;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Agents;
using SC.LK.Application.Domains.Responses.DistributivesVersions;
using SC.LK.Application.Domains.Responses.Terminals;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SC.LK.Infrastructure.InternalConnector.Adaptors
{
    public class RCClient : IRepositoryConfigurationServiceAdaptor
    {
        private string _baseUrl = String.Empty;
        private RepositoryClientOptions _settingsClientOptions;
        private readonly RestClient _client;
        
        /// <summary>
        /// RCClient
        /// </summary>
        /// <param name="options"></param>
        public RCClient(IOptions<RepositoryClientOptions> options)
        {
            _settingsClientOptions = options.Value;
            _baseUrl = _settingsClientOptions.BaseUrl;
            _client = new RestClient(_baseUrl);
        }
        
        /// <summary>
        /// AuthHeader
        /// </summary>
        public string AuthHeader { get; set; }

        #region Agent

        /// <summary>
        /// AddAgentAsync
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
         public async Task<Guid> AddAgentAsync(AgentView body)
        {
            string resurce = "Agent/addAgent";
            var request = CreateRequest(resurce, Method.POST, body);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// UpdateAgentAsync
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAgentAsync(Guid agentId, AgentView body)
        {
            string resurce = $"Agent/updateAgent/{agentId}";
            var request = CreateRequest(resurce, Method.PUT, body);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        public async Task<FileStreamResult> GetDistributiveAgentAsync()
        {
            string resurce = $"Agent/getDistributive";
            var request = CreateRequest(resurce, Method.GET, null);
            var res = await GetDistributive(request:request);
            return res;
        }

        /// <summary>
        /// GetAgentByAgentIdAsync
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public async Task<AgentView> GetAgentByAgentIdAsync(Guid? agentId)
        {
            string resurce = $"Agent/getAgentByAgentId?agentId={agentId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<AgentView>(request:request);
            return response;
        }

        /// <summary>
        /// GetManagedTerminalsIdsAsync
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public async Task<ManagedTerminalsView> GetManagedTerminalsIdsAsync(Guid? agentId)
        {
            string resurce = $"Agent/getManagedTerminalsIds?agentId={agentId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<ManagedTerminalsView>(request:request);
            return response;
        }

        /// <summary>
        /// CheckForUpdateAsync
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="version"></param>
        public async Task CheckForUpdateAsync(Guid? agentId, string version)
        {
            string resurce = $"Agent/checkForUpdate?agentId={agentId}&version={version}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<string>(request:request);
            return;
        }

        /// <summary>
        /// GetUpdateAsync
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="version"></param>
        public async Task GetUpdateAsync(Guid? agentId, string version)
        {
            string resurce = $"Agent/getUpdate?agentId={agentId}&version={version}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<string>(request:request);
            return;
        }
        
        /// <summary>
        /// GetAgentsByKontragentId
        /// </summary>
        /// <param name="kontrAgentId"></param>
        /// <returns></returns>
        public async Task<AgentsView> GetAgentsByKontragentId(Guid? kontrAgentId)
        {
            string resurce = $"Agent/getAgentByKontragentIdExtended?kontragentId={kontrAgentId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<AgentsView>(request:request);
            return response;
        }

        /// <summary>
        /// GetAgentsByAgentsIdExtendedAsync
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<AgentsViewExtended> GetAgentsByAgentsIdExtendedAsync(AgentsView body)
        {
            string resurce = "Agent/getAgentsByAgentsIdExtended";
            var request = CreateRequest(resurce, Method.POST, body);
            var response = await GetResponse<AgentsViewExtended>(request:request);
            return response;
        }

        /// <summary>
        /// GetAgentsByDivisionId
        /// </summary>
        /// <param name="divisionId"></param>
        /// <returns></returns>
        public async Task<AgentsView> GetAgentsByDivisionId(Guid? divisionId)
        {
            string resurce = $"Agent/getAgentByDivisionIdExtended?divisionId={divisionId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<AgentsView>(request:request);
            return response;
        }

        public async Task<bool> DeleteAgentByAgentId(Guid agentId)
        {
            string resurce = $"Agent/deleteAgentByAgentId?agentId={agentId}";
            var request = CreateRequest(resurce, Method.DELETE, null);
            var responce = await GetResponse(request:request);
            return responce;
        }
        #endregion

        #region BusinessProcess

        /// <summary>
        /// AddBusinessProcessAsync
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> AddBusinessProcessAsync(BusinessProcessView body)
        {
            string resurce = "BusinessProcess/addBusinessProcess";
            var request = CreateRequest(resurce, Method.POST, body);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// UpdateBusinessProcessAsync
        /// </summary>
        /// <param name="businessProcessId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateBusinessProcessAsync(Guid businessProcessId, BusinessProcessView body)
        {
            string resurce = $"BusinessProcess/updateBusinessProcess/{businessProcessId}";
            var request = CreateRequest(resurce, Method.PUT, body);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// GetBusinessProcessByKontragentIdAsync
        /// </summary>
        /// <param name="kontragentId"></param>
        /// <returns></returns>
        public async Task<List<BusinessProcessWithOutJsonBodyView>> GetBusinessProcessByKontragentIdAsync(Guid? kontragentId)
        {
            string resurce = $"BusinessProcess/getBusinessProcessByKontragentId?KontragentId={kontragentId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<List<BusinessProcessWithOutJsonBodyView>>(request:request);
            return response;
        }

        /// <summary>
        /// GetBusinessProcessByBusinessProcessIdAsync
        /// </summary>
        /// <param name="businessProcessId"></param>
        /// <returns></returns>
        public async Task<BusinessProcessView> GetBusinessProcessByBusinessProcessIdAsync(Guid? businessProcessId)
        {
            string resurce = $"BusinessProcess/getBusinessProcessByBusinessProcessId?businessProcessId={businessProcessId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<BusinessProcessView>(request:request);
            return response;
        }

        /// <summary>
        /// DeleteBusinessProcessByBusinessProcessIdAsync
        /// </summary>
        /// <param name="businessProcessId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBusinessProcessByBusinessProcessIdAsync(Guid? businessProcessId)
        {                
            string resurce = $"BusinessProcess/delete/{businessProcessId}";
            var request = CreateRequest(resurce, Method.DELETE, null);
            var response = await GetResponse(request: request);
            return response;
        }

        #endregion

        #region Configurations

        /// <summary>
        /// AddConfigurationAsync
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> AddConfigurationAsync(ConfigurationView body)
        {
            string resurce = "Configurations/addConfiguration";
            var request = CreateRequest(resurce, Method.POST, body);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// UpdateConfigurationAsync
        /// </summary>
        /// <param name="configurationId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateConfigurationAsync(Guid configurationId, ConfigurationView body)
        {
            string resurce = $"Configurations/updateConfiguration/{configurationId}";
            var request = CreateRequest(resurce, Method.PUT, body);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// GetConfigurationByKontragentIdAsync
        /// </summary>
        /// <param name="kontragentId"></param>
        /// <returns></returns>
        public async Task<List<ConfigurationView>> GetConfigurationByKontragentIdAsync(Guid? kontragentId)
        {
            string resurce = $"Configurations/getConfigurationByKontragentId?KontragentId={kontragentId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<List<ConfigurationView>>(request:request);
            return response;
        }

        #endregion

        #region ConfigurationVersion

        /// <summary>
        /// AddConfigurationVersionAsync
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> AddConfigurationVersionAsync(ConfigurationVersionView body)
        {
            string resurce = "ConfigurationVersion/addConfigurationVersion";
            var request = CreateRequest(resurce, Method.POST, body);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// UpdateConfigurationVersionAsync
        /// </summary>
        /// <param name="configurationVersionId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateConfigurationVersionAsync(Guid configurationVersionId, ConfigurationVersionView body)
        {
            string resurce = $"ConfigurationVersion/updateConfigurationVersion/{configurationVersionId}";
            var request = CreateRequest(resurce, Method.PUT, body);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// ActivateConfigurationVersionAsync
        /// </summary>
        /// <param name="configurationVersionId"></param>
        /// <returns></returns>
        public async Task<Guid> ActivateConfigurationVersionAsync(Guid configurationVersionId)
        {
            string resurce = $"ConfigurationVersion/activateConfigurationVersion/{configurationVersionId}";
            var request = CreateRequest(resurce, Method.PUT, null);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// GetConfigurationVersionsByConfigurationIdAsync
        /// </summary>
        /// <param name="configurationId"></param>
        /// <returns></returns>
        public async Task<List<ConfigurationVersionView>> GetConfigurationVersionsByConfigurationIdAsync(Guid? configurationId)
        {
            string resurce = $"ConfigurationVersion/getConfigurationVersionsByConfigurationId?configurationId={configurationId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<List<ConfigurationVersionView>>(request:request);
            return response;
        }

        /// <summary>
        /// GetConfigurationVersionByConfigurationVersionIdAsync
        /// </summary>
        /// <param name="configurationVersionId"></param>
        /// <returns></returns>
        public async Task<ConfigurationVersionView> GetConfigurationVersionByConfigurationVersionIdAsync(Guid? configurationVersionId)
        {
            string resurce = $"ConfigurationVersion/getConfigurationVersionByConfigurationVersionId?configurationVersionId={configurationVersionId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<ConfigurationVersionView>(request:request);
            return response;        
        }

        /// <summary>
        /// DeleteConfigurationVersionByVersionIdAsync
        /// </summary>
        /// <param name="ConfigurationVersionId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteConfigurationVersionByVersionIdAsync(Guid? ConfigurationVersionId)
        {
            string resurce = $"ConfigurationVersion/deleteConfigurationVersionByVersionId?configurationVersionId={ConfigurationVersionId}";
            var request = CreateRequest(resurce, Method.DELETE, null);
            var response = await GetResponse(request:request);
            return response;        
        }

        #endregion

        #region Terminal

        /// <summary>
        /// AddTerminalAsync
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> AddTerminalAsync(TerminalView body)
        {
            string resurce = "Terminal/addTerminal";
            var request = CreateRequest(resurce, Method.POST, body);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// UpdateTerminalAsync
        /// </summary>
        /// <param name="terminalId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateTerminalAsync(Guid terminalId, TerminalView body)
        {
            string resurce = $"Terminal/updateTerminal/{terminalId}";
            var request = CreateRequest(resurce, Method.PUT, body);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// GetTerminalByTerminalIdAsync
        /// </summary>
        /// <param name="terminalId"></param>
        /// <returns></returns>
        public async Task<TerminalView> GetTerminalByTerminalIdAsync(Guid? terminalId)
        {
            string resurce = $"Terminal/getTerminalByTerminalId?terminalId={terminalId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<TerminalView>(request:request);
            return response;
        }

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="terminalId"></param>
        /// <param name="updateBy"></param>
        /// <returns></returns>
        public async Task<Guid> DeleteAsync(Guid terminalId, string updateBy)
        {
            string resurce = $"Terminal/delete/{terminalId}/{updateBy}";
            var request = CreateRequest(resurce, Method.PUT, null);
            var response = await GetResponse<Guid>(request:request);
            return response;
        }

        /// <summary>
        /// GetConfigurationVervionByTerminalIdAsync
        /// </summary>
        /// <param name="terminalId"></param>
        /// <returns></returns>
        public async Task<ConfigurationVersionSignView> GetConfigurationVervionByTerminalIdAsync(Guid? terminalId)
        {
            string resurce = $"Terminal/getConfigurationVervionByTerminalId?terminalId={terminalId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<ConfigurationVersionSignView>(request:request);
            return response;
        }
        
        /// <summary>
        /// GetTerminalsByDivisionIdAsync
        /// </summary>
        /// <param name="divisionId"></param>
        /// <returns></returns>
        public async Task<ManagedTerminalsViewExtended> GetTerminalsByDivisionIdAsync(Guid? divisionId)
        {
            string resurce = $"/Terminal/getTerminalsByDivisionId?divisionId={divisionId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<ManagedTerminalsViewExtended>(request:request);
            return response;
        }

        /// <summary>
        /// GetTerminalsByKontragentIdAsync
        /// </summary>
        /// <param name="kontragentId"></param>
        /// <returns></returns>
        public async Task<ManagedTerminalsViewExtended> GetTerminalsByKontragentIdAsync(Guid? kontragentId)
        {
            string resurce = $"/Terminal/getTerminalsByKontragentId?kontragentId={kontragentId}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<ManagedTerminalsViewExtended>(request:request);
            return response;
        }
        
        /// <summary>
        /// CheckForUpdate2Async
        /// </summary>
        /// <param name="terminalId"></param>
        /// <param name="version"></param>
        public async Task CheckForUpdate2Async(Guid? terminalId, string version)
        {
            string resurce = $"Terminal/checkForUpdate?terminalId={terminalId}&version={version}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<string>(request:request);
            return;
        }

        /// <summary>
        /// GetUpdate2Async
        /// </summary>
        /// <param name="terminalId"></param>
        /// <param name="version"></param>
        public async Task GetUpdate2Async(Guid? terminalId, string version)
        {
            string resurce = $"Terminal/getUpdate?terminalId={terminalId}&version={version}";
            var request = CreateRequest(resurce, Method.GET, null);
            var response = await GetResponse<string>(request:request);
            return;
        }

        public async Task<string> GetDistributiveTerminalAsync()
        {
            string resurce = $"Terminal/getDistributive";
            var request = CreateRequest(resurce, Method.GET, null);
            var res = await GetDistrLink(request:request);
            return res;
        }

        public async Task<bool> AssignLicenceToTerminalAsync(LicenceTerminalView body)
        {
            string resurce = "Terminal/assignLicenceToTerminal";
            var request = CreateRequest(resurce, Method.PUT, body);
            var response = await GetResponse(request: request);
            return response;       
        }

        public async Task<bool> ReleaseLicenceFromTerminalAsync(LicenceTerminalView body)
        {
            string resurce = "Terminal/releaseLicenceFromTerminal";
            var request = CreateRequest(resurce, Method.PUT, body);
            var response = await GetResponse(request: request);
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
            var request = new RestRequest(resource, method) { RequestFormat = DataFormat.Json};
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
            var response  =  await _client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return JsonConvert.DeserializeObject<T>("{}");
            }
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return JsonConvert.DeserializeObject<T>("{}");
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return JsonConvert.DeserializeObject<T>("{}");
            }

            throw new Exception(JsonSerializer.Serialize(new { Response = response.Content, Request = request}));
        }
        
        /// <summary>
        /// Обработка респонса
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<bool> GetResponse(IRestRequest request)
        {
            var response  =  await _client.ExecuteAsync(request);
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

            throw new Exception(JsonSerializer.Serialize(new { Response = response.Content, Request = request}));
        }

        /// <summary>
        /// Обработка респонса
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<FileStreamResult> GetDistributive(IRestRequest request)
        {
            var response  =  await _client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                MemoryStream stream = new MemoryStream(response.RawBytes);
                FileStreamResult result = new FileStreamResult(stream, response.ContentType){FileDownloadName = "SC.SiteAgent.msi"};
                return result;
            }
            return null;
        }

        private async Task<string> GetDistrLink(IRestRequest request)
        {
            var response  =  await _client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Content;
            }
            return null;
        }
        
        #region Instructions
        /// <summary>
        /// AddInstructions
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> AddInstruction(InstructionsRootView body)
        {
            var res = "Instructions/addInstructions";
            var request = CreateRequest(res, Method.POST, body);
            var response = await GetResponse<Guid>(request: request);
            return response;  
        }
        /// <summary>
        /// UpdateInstructions
        /// </summary>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateInstructions (InstructionsRootView body)
        {
            var res = $"Instructions/updateInstructions/{body.InstructionId}";
            var request = CreateRequest(res, Method.PUT, body);
            var response = await GetResponse<Guid>(request: request);
            return response;
        }
        /// <summary>
        /// GetInstructionsByInstructionsId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<InstructionsRootView> GetInstructionsByInstructionsId (Guid id)
        {
            var res = "Instructions/getInstructionsByInstructionsId" + "?instructionsId="+$"{id}";
            var request = CreateRequest(res, Method.GET,null);
            var response = await GetResponse<InstructionsRootView>(request: request);
            return response;
        }
        /// <summary>
        /// DeleteInstruction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Guid> DeleteInstruction (Guid id)
        {
            var res = $"Instructions/delete/{id}";
            var request = CreateRequest(res, Method.DELETE, id);
            var response = await GetResponse<Guid>(request: request);
            return response;
        }
        /// <summary>
        /// GetFullConfig
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetFullConfig ()
        {
            var res = $"Instructions/getFullConfig";
            var request = CreateRequest(res, Method.GET, null);
            var response = await GetResponse<string>(request: request);
            return response;
        }

        #endregion

        #region Parameters
        /// <summary>
        /// AddParameters
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> AddParameters (InstructionsParameterView body)
        {
            var res = $"Parameters/addParameters";
            var request = CreateRequest(res, Method.POST, body);
            var response = await GetResponse<Guid>(request: request);
            return response;
        }
        /// <summary>
        /// UpdateParameters
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateParameters (InstructionsParameterView body)
        {
            var res = $"Parameters/updateParameters/{body.InstructionId}";
            var request = CreateRequest(res, Method.PUT, body);
            var response = await GetResponse<Guid>(request: request);
            return response;
        }
        /// <summary>
        /// GetParametersByParameterId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<InstructionsParameterView> GetParametersByParameterId (Guid id)
        {
            var res = "Parameters/getParametersByParametersId" + "?parametersId=" + $"{id}";
            var request = CreateRequest(res, Method.GET, null);
            var response = await GetResponse<InstructionsParameterView>(request: request);
            return response;
        }
        /// <summary>
        /// DeleteParameters
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Guid> DeleteParameters(Guid id)
        {
            var res = $"Parameters/delete/{id}";
            var request = CreateRequest(res, Method.DELETE, null);
            var response = await GetResponse<Guid>(request: request);
            return response;
        }

        #endregion

        #region ParametersValues

        /// <summary>
        /// AddParameters
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> AddParametersValues (InstructionsParametersValueView body)
        {
            var res = $"ParametersValues/addParametersValues";
            var request = CreateRequest(res, Method.POST, body);
            var response = await GetResponse<Guid>(request: request);
            return response;
        }
        /// <summary>
        /// UpdateParameters
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateParametersValues (InstructionsParametersValueView body)
        {
            var res = $"ParametersValues/updateParametersValues/{body.ValueId}";
            var request = CreateRequest(res, Method.PUT, body);
            var response = await GetResponse<Guid>(request: request);
            return response;
        }
        /// <summary>
        /// GetParametersByParameterId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<InstructionsParametersValueView> GetParametersValuesByParameterValuesId (Guid id)
        {
            var res = "ParametersValues/getParametersValuesByParametersValuesId" + "?parametersValuesId=" + $"{id}";
            var request = CreateRequest(res, Method.GET, null);
            var response = await GetResponse<InstructionsParametersValueView>(request: request);
            return response;
        }
        /// <summary>
        /// DeleteParameters
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Guid> DeleteParametersValues(Guid id)
        {
            var res = $"Parameters/delete/{id}";
            var request = CreateRequest(res, Method.DELETE, null);
            var response = await GetResponse<Guid>(request: request);
            return response;
        }

        #endregion
        /// <summary>
        /// UploadTerminalDistributive
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<UploadTerminalDistributiveResponse> UploadTerminalDistributive(
            UploadTerminalDistributiveRequest body)
        {
            var res = $"Terminal/uploadDistributive";
            var request = CreateRequest(res, Method.POST, body);
            var response = await GetResponse<UploadTerminalDistributiveResponse>(request: request);
            return response;
        }
        /// <summary>
        /// UploadAgentDistributive
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<UploadAgentDistributiveResponse> UploadAgentDistributive(
            UploadAgentDistributiveRequest body)
        {
            var res = $"Agent/uploadDistributive";
            var request = CreateRequestFromForm(res,Method.POST,body.File,body.Version,body.ChangeLog);
            var response = await GetResponse<UploadAgentDistributiveResponse>(request: request);
            return response;
        }
        /// <summary>
        /// Создание реквеста с файлом
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private IRestRequest CreateRequestFromForm(string res,Method method, IFormFile file, string Version, string ChangeLog)
        {
            var request = new RestRequest(res, method) { RequestFormat = DataFormat.Json};
            _client.Authenticator = new JwtAuthenticator(this.AuthHeader);
            byte[] bytes = new byte[file.Length];
            using var fileStream = file.OpenReadStream();
            fileStream.Read(bytes, 0, (int)file.Length);
            request.AddFileBytes(file.Name,bytes,file.FileName);
            request.AddParameter("Version",Version);
            request.AddParameter("ChangeLog",ChangeLog);
            return request;
        }

        public async Task<DistributivesView> GetAgentDistributiveVersion(GetDistributivesVersionsRequest body)
        {
            var res1 = $"Agent/getActiveDistributiveVersion";
            var request1 = CreateRequest(res1,Method.GET, null);
            var response1 = await GetResponse<DistributivesView>(request: request1);
            return response1;
        }
        public async Task<DistributivesView> GetTerminalDistributiveVersion(GetDistributivesVersionsRequest body)
        {
            var res2 = $"Terminal/getActiveDistributiveVersion";
            var request2 = CreateRequest(res2,Method.GET, null);
            var response2 = await GetResponse<DistributivesView>(request: request2);
            return response2;
        }
        
        public async Task<List<Guid?>> GetAllTemplatesByContragentId(Guid id)
        {
            var res2 = $"BusinessProcess/getAllTemplatesByContragentId?KontragentId={id}";
            var request2 = CreateRequest(res2,Method.GET, null);
            var response2 = await GetResponse<List<Guid?>>(request: request2);
            return response2;
        }
        
    }
}
