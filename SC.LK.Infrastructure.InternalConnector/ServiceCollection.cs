using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.CloudApiService;
using SC.LK.Application.Domains.IdentityService;
using SC.LK.Infrastructure.InternalConnector.Adaptors;
using SC.LK.Application.Domains.InternalConnectors.BillingService;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.SigningEncryptionService;

namespace SC.LK.Infrastructure.InternalConnector
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// InternalConnectors
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddInfrastructureInternalConnectors(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.Configure<CloudApiClientOptions>(configuration.GetSection("CloudApiClientConnecting"));
            services.Configure<IdentityServiceClientOptions>(configuration.GetSection("ISClientConnecting"));
            services.Configure<RepositoryClientOptions>(configuration.GetSection("RCClientConnecting"));
            services.Configure<SigningEncryptionOptions>(configuration.GetSection("SEClientConnecting"));
            services.Configure<BillingServiceOptions>(configuration.GetSection("BClientConnecting"));
            
            services.AddTransient<IISClient, ISClient>();
            services.AddTransient<ICloudApiServiceAdaptor, CloudClient>();
            services.AddTransient<IRepositoryConfigurationServiceAdaptor, RCClient>();
            services.AddTransient<ISigningEncryptionAdaptor, SigningEncryptionClient>();
            services.AddTransient<IBillingServiceAdaptor, BillingServiceClient>();
        }
    }
}