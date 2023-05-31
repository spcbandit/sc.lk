using MediatR;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;
using AutoMapper;
using SC.LK.Application.Mappings;

namespace SC.LK.Application
{
    /// <summary>
    /// Шина регистрации сервисов
    /// </summary>
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtension).GetTypeInfo().Assembly;
            services.AddMediatR(assembly);
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}