using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;
using SC.LK.Infrastructure.Database.Repositories;

namespace SC.LK.Infrastructure.Database.MethodsConfigurator;

public class MethodsConfiguratorService:IHostedService
{
    private readonly IEnumerable<EndpointDataSource> _endpointSources;
    private readonly IRepository<MethodAccessTypeEntity> _repository;
    private readonly IRepository<MethodWithRoles> _repositoryMid;

    public MethodsConfiguratorService(IEnumerable<EndpointDataSource> endpointSources,IRepository<MethodAccessTypeEntity> repository, IRepository<MethodWithRoles> repositoryMid )
    {
        _endpointSources = endpointSources;
        _repository = repository;
        _repositoryMid = repositoryMid;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        ReloadMethods();
        return StopAsync(cancellationToken);
    }
    string[] GetEndPoints()
    {
        var endpoints = _endpointSources
            .SelectMany(es => es.Endpoints)
            .OfType<RouteEndpoint>();
        var output = endpoints.Select(e => e.RoutePattern.RawText).ToArray();
        return output;
    }
    bool ReloadMethods()
    {
        var endpoints = GetEndPoints();
        foreach (var i in endpoints)
        {
            var get = _repository.Get(x => x.MethodName == i).FirstOrDefault();
            if (get == null)
            {
                var methodId = Guid.NewGuid();
                var createMethod = _repository.Create(new MethodAccessTypeEntity()
                    { Id = methodId, Updated = DateTime.Now, MethodName = i });
                var roleId = new Guid("08daadc6-a774-4b18-86a3-eed249385cb7");
                var bind = _repositoryMid.Create
                (
                    new MethodWithRoles()
                    {
                        Id = Guid.NewGuid(), 
                        Updated = DateTime.Now, 
                        AvailableRoleId = roleId,
                        MethodAccessTypesEntitiesId = methodId
                    }
                );
            }
        }
        return false;
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}