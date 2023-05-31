using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.ExternalConnectors.DaDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Test;

internal class Users_CreateUpdateDeleteGet_Tester
{
    private IRepository<UserEntity> _repository;
    private IServiceScope _scope;

    [SetUp]
    async public Task Setup()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _scope = webAppFactory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IRepository<UserEntity>>();
    }

    [Test]
    // Цикл: Создание - Обновление - Удаление роли
    public void AddUpdateDeleteAvailabelRolesTest_result1()
    {
        //arrange
        UserEntity content = new UserEntity
        {
            Id = new Guid("08da6eea-bbab-4079-8b88-707238265706"),
            IsActive = true,
            MainContractor = new Guid("08da6ee6-00a6-4da4-8c9a-d050b3127e14"),
            Name = "Test_A",
            Parent = "TestParent",
            Family = "TestFamily",
            Login = "TestLogin",
            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3RyaW5nIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoie1wiVHlwZVwiOjIsXCJOYW1lXCI6XCJcIixcIkFjY2Vzc1R5cGVcIjozLFwiSWRcIjpcIjA4ZGE2ZWU2LTAyZDEtNDZlNi04N2NlLTg5OWI1NjBjZWVlM1wiLFwiVXBkYXRlZFwiOlwiMjAyMi0wNy0yNlQxNDowNTozNS44Mzc4NjhcIn0iLCJuYmYiOjE2NTk2MDEwOTksImV4cCI6MTY1OTY4NzQ5OSwiaXNzIjoiU0MuTEsuQ0xJRU5UIiwiYXVkIjoiU0MuTEsuQkFDS0VORCJ9.sm-I21vUD5GljuHDGpHHOdWBXdyNZYwFB71viM9Briw",
            Password = "password",
            IsDelete = false,
            Updated = DateTime.Now,
            AuthCode = "000000",
            AvailableRoles = new Guid("08daadc6-a774-4b18-86a3-eed249385cb7"),
            IsSuper = false
        };
        //act        
        var temp = _repository.Create(content);
        //assert
        Assert.AreEqual("1", temp.ToString());

        //arrange
        content.Name = "Test_B";
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

    [Test]
    async public Task getAllUsers_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var contractorId = "?ContractorId=08dabdd4-2ce2-4667-8693-6917cb95ecac";
        var userId = "&UserId=08dabdd4-495e-4e3d-8b5e-bca7f4a099fe";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "users/getAllUsers" + contractorId + userId);
        //Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }
}
