using AutoMapper;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.InternalConnectors.BillingService;
using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Mappings;

public class MappingProfile : Profile {
    public MappingProfile() {
        // Add as many of these lines as you need to map your objects
        CreateMap<BusinessProcessView, BusinessProcessViewDto>();
        CreateMap<BusinessProcessWithOutJsonBodyView, BusinessProcessViewDto>();
        CreateMap<ConfigurationsBusinessProcessView, ConfigurationsBusinessProcessViewDto>();
        CreateMap<ConfigurationVersionSignView, ConfigurationVersionSignViewDto>();
        
        CreateMap<ConfigurationVersionView, ConfigurationVersionViewDto>();
        
        CreateMap<BalanceEntity, BalanceDto>();
        CreateMap<BillingFaceEntity, BillingFaceDto>();
        CreateMap<BonusesEntity, BonusesDto>();
        CreateMap<DivisionEntity, DivisionDto>();
        CreateMap<KeysEntity, KeysDto>();
        CreateMap<PartnerEntity, PartnerDto>();
        CreateMap<PaymentSystemEntity, PaymentSystemDto>();
        CreateMap<PricesEntity, PricesDto>();
        CreateMap<SubscriptionEntity, SubscriptionDto>();
        CreateMap<TerminalEntity, TerminalDto>();


        CreateMap<TerminalView, TerminalDto>();
        CreateMap<UserEntity, UserDto>();
        CreateMap<UserEntity, UserInfoDto>();
        CreateMap<UserEntity, BaseUserDto>();
        CreateMap<ContractorEntity, ContractorDto>();
        CreateMap<ContractorEntity, BaseContractorDto>();
        
        CreateMap<ManagedTerminalsViewExtended, TerminalsByIdDto>();
        CreateMap<TerminalView, TerminalByIdDto>();
        
        CreateMap<AgentView, AgentDto>();
        CreateMap<AgentsView, AgentsViewDto>();

        CreateMap<LicenseView, LicenseViewDto>();
        
        CreateMap<InstructionsRootView, InstructionsRootDto>();
        CreateMap<InstructionsRootDto, InstructionsRootView>();
        
        CreateMap<InstructionsSettingView, InstructionsSettingDto>();
        CreateMap<InstructionsSettingDto, InstructionsSettingView>();
        
        CreateMap<InstructionsParameterView, InstructionsParameterDto>();
        CreateMap<InstructionsParameterDto, InstructionsParameterView>();
        
        CreateMap<InstructionsParametersValueView, InstructionsParametersValueDto>();
        CreateMap<InstructionsParametersValueDto, InstructionsParametersValueView>();
        
        CreateMap<InstructionsEventView, InstructionsEventDto>();
        CreateMap<InstructionsEventDto, InstructionsEventView>();
        
        CreateMap<DistributivesView, GetDistributiveAgentResponse>();
        CreateMap<GetDistributiveAgentResponse, DistributivesView>();
    }
}