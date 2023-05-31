using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.Ocsp;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.AvailableRoles;
using SC.LK.Application.Handlers.AvailabeRoles;
using SC.LK.Infrastructure.Database.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace SC.LK.Test;

internal class AvailabeRoles_CreateUpdateDeleteGet_Tester
{
    //private IRepository<AvailableRolesEntity>? _availableRolesSources;
    //private ScanCityLKContext _context;
    //private AddAvailableRoleRequest _request;
    //private IRepository<AvailableRolesEntity> _repositoryMid;
    // private WebApplicationFactory<Program> _client;
    private IRepository<AvailableRolesEntity> _repository;
    private IServiceScope _scope;

    [SetUp]
    async public Task Setup()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _scope = webAppFactory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IRepository<AvailableRolesEntity>>();
    }

    [Test]
    // Цикл: Создание - Обновление - Удаление роли
    public void AddUpdateDeleteAvailabelRolesTest_result1()
    {
        //arrange
        AvailableRolesEntity content = new AvailableRolesEntity
        {
            Id = new Guid("08daadc6-a774-4b18-86a3-eed249385cb5"),
            RoleName = "test_A",
            RoleType = 1,
            Updated = DateTime.Now,
        };
        //act        
        var temp = _repository.Create(content);
        //assert
        Assert.AreEqual("1", temp.ToString());

        //arrange
        content.RoleName = "test_B";
        content.RoleType = 2;
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
    async public Task GetAllAvailableRolesHandlerTest_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "availableRoles/getAllAvailableRoles");
        Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }

    [Test]
    async public Task GetAvailableRolesHandlerTest_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var availableRoleId = "?AvailableRoleId=08daac3b-dde0-4183-83ce-07b64affb783";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "availableRoles/getAvailableRoles" + availableRoleId);
        //Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }
}
