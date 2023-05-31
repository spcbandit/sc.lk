using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;


namespace SC.LK.Test.MethodAccess;

internal class MethodWithRoles_BindUpdateDeleteGet_Tester
{
    private IRepository<MethodWithRoles> _repository;
    private IServiceScope _scope;

    [SetUp]
    async public Task Setup()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _scope = webAppFactory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IRepository<MethodWithRoles>>();
    }

    [Test]
    // Цикл: Создание - Обновление - Удаление роли
    public void CreateUpdateDeleteMethodWithRoles_result1()
    {
        //arrange
        MethodWithRoles content = new MethodWithRoles
        {
            Id = new Guid("08dade84-ddb6-4318-8b5c-ef7640966821"),
            AvailableRoleId = new Guid("08daadc6-a774-4b18-86a3-eed249385cb1"),
            MethodAccessTypesEntitiesId = new Guid("be770e80-1567-44bd-9a19-19ddf811d6e1") ,
            Updated = DateTime.Now
        };
        //act        
        var temp = _repository.Create(content);
        Console.WriteLine(temp.ToString());
        //assert
        Assert.AreEqual("1", temp.ToString());

        //arrange
        content.Updated = DateTime.Now;
        //act   
        temp = _repository.Update(content);
        //assert
        Assert.AreEqual("1", temp.ToString());

        //act   
        temp = _repository.Remove(content);
        //assert
        Assert.AreEqual("1", temp.ToString());
    }
}
