using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SC.LK.Test.Terminals;

internal class Terminals_CreateUpdateDelete_Tester
{
    private IRepository<TerminalEntity> _repository;
    private IRepository<DivisionEntity> _subRepository;
    private IServiceScope _scope;

    [SetUp]
    async public Task Setup()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _scope = webAppFactory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IRepository<TerminalEntity>>();
        _subRepository = _scope.ServiceProvider.GetRequiredService<IRepository<DivisionEntity>>();
    }

    [Test]
    // Цикл: Создание - Обновление - Удаление роли
    public void CreateUpdateDeleteTerminals_result1()
    {
        DivisionEntity subContentDivision = new DivisionEntity
        {
            Id = new Guid("08daadc6-a774-4b18-86a3-eed249385cb5"),
            Address = "TestAdress",
            Name = "TestName",
            PIN = "1",
            IsActive = true,
            Host = "TestHost",
            СontractorId = new Guid("08da713e-5b50-4f6e-8f83-98a31a1e675f"),
            Updated = DateTime.Now,
        };
        //arrange
        TerminalEntity content = new TerminalEntity
        {
            Id = new Guid("08daadc6-a774-4b18-86a3-eed249385cb5"),
            Name = "Test_A",
            Deviceid = "08daadc6-a774-4b18-86a3-eed249385c13",
            AddedScanner = DateTime.Now,
            Division = subContentDivision,
            SubscriptionId = new Guid("08daadc6-a774-4b18-86a3-eed249385c11"),
            Updated = DateTime.Now,
        };
        //act        
        var temp = _repository.Create(content);
        //assert
        Assert.AreEqual("2", temp.ToString());

        //arrange
        content.Name = "Test_B";
        content.Deviceid = "08daadc6-a774-4b18-86a3-eed249385cb6";
        content.AddedScanner = DateTime.Now;
        //content.SubscriptionId = new Guid("08daadc6-a774-4b18-86a3-eed249385cb5");
        content.Updated = DateTime.Now;
        //act   
        temp = _repository.Update(content);
        //assert
        Assert.AreEqual("1", temp.ToString());

        //act   
        _repository.Remove(content);
        _subRepository.Remove(subContentDivision);

        //assert
        Assert.AreEqual("1", temp.ToString());
    }
}
