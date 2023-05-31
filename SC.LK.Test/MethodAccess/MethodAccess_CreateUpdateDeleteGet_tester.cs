using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Test.MethodAccess;

internal class MethodAccess_CreateUpdateDeleteGet_tester
{
    private IRepository<MethodAccessTypeEntity> _repository;
    private IServiceScope _scope;

    [SetUp]
    async public Task Setup()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _scope = webAppFactory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IRepository<MethodAccessTypeEntity>>();
    }

    [Test]
    // Цикл: Создание - Обновление - Удаление роли
    public void CreateUpdateDeleteMethodAccess_result1()
    {
        //arrange
        MethodAccessTypeEntity content = new MethodAccessTypeEntity
        {
            Id = new Guid("08dade84-ddb6-4318-8b5c-ef7640966826"),
            MethodName = "Test/Name",
            Updated = DateTime.Now
        };
        //act        
        var temp = _repository.Create(content);
        Console.WriteLine(temp.ToString());
        //assert
        Assert.AreEqual("1", temp.ToString());

        //arrange
        content.MethodName = "New/Test/Name";
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
    async public Task GetMethodAccess_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var id = "?Id=a6cd863d-5327-471d-aaf9-6e24086a8f5e";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "methodAccess/getMethodAccess" + id);
        Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }

    [Test]
    async public Task GetAllMethodAccess_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "methodAccess/getAllMethodAccess");
        Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }
}
