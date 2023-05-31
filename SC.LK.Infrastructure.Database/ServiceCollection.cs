using Microsoft.Extensions.DependencyInjection;

using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SC.LK.Infrastructure.Database.Contexts;
using SC.LK.Infrastructure.Database.MethodsConfigurator;

namespace SC.LK.Infrastructure.Database
{
    public static class ServiceCollectionExtention
    {
        public static void AddInfrastructureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ScanCityLKContext>(options =>
                  options.UseMySql(configuration.GetConnectionString("DBConnection"),
                  new MySqlServerVersion(new Version(5, 6, 45))));
            
            
            services.AddTransient<IRepository<AdminEntity>, AdminRespository>();
            
            services.AddTransient<IRepository<BillingFaceEntity>, BillingFaceRepository>();

            services.AddTransient<IRepository<ContractorEntity>, ContractorRepository>();

            services.AddTransient<IRepository<DivisionEntity>, DivisionRepository>();

            services.AddTransient<IRepository<PartnerEntity>, PartnerRespository>();

            services.AddTransient<IRepository<TerminalEntity>, TerminalRepository>();

            services.AddTransient<IRepository<UserEntity>, UserRespository>();
            
            services.AddTransient<IRepository<TicketEntity>, TicketRepository>();

            services.AddTransient<IRepository<AvailableRolesEntity>, AvailableRolesRepository>();
            
            services.AddTransient<IRepository<NotificationEntity>, NotificationRepository>();

            services.AddTransient<IRepository<QuarantineEntity>, QuarantineRepository>();
        }

        public static void AddMethodConf(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MethodsConfiguratorContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DBConnection"),
                    new MySqlServerVersion(new Version(5, 6, 45))), ServiceLifetime.Singleton);
            
            //services.AddHostedService<MethodsConfiguratorService>();
            services.AddTransient<IRepository<MethodAccessTypeEntity>, MethodAccessTypeRepository>();
            services.AddTransient<IRepository<MethodWithRoles>, MethodRolesRepository>();
        }
    }
}
