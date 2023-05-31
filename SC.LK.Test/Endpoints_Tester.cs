using System.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

namespace SC.LK.Test;

public class Tests
{
    private IEnumerable<EndpointDataSource> _endpointSources;
    private ScanCityLKContext _context;
    private IRepository<MethodAccessTypeEntity> _repository;
    private IRepository<MethodWithRoles> _repositoryMid;
    private IServiceScope _scope;
    [SetUp]
    public void Setup()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        _endpointSources = webAppFactory.Services.GetRequiredService<IEnumerable<EndpointDataSource>>();
        _scope = (webAppFactory.Services.GetRequiredService<IServiceScopeFactory>()).CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IRepository<MethodAccessTypeEntity>>();
        _repositoryMid = _scope.ServiceProvider.GetRequiredService<IRepository<MethodWithRoles>>();
    }

    [Test]
    public void Test1()
    {
        var endpoints = _endpointSources
            .SelectMany(es => es.Endpoints)
            .OfType<RouteEndpoint>();
        var output = endpoints.Select(e => e.RoutePattern.RawText).ToArray();
        foreach (var i in output)
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

        var allMethods = _repository.Get().ToArray();
        Assert.IsTrue(output.Length <= allMethods.Length);
    }
}