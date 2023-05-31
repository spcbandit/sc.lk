using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace SC.LK.Test;

internal class DivisionHandler_CreateUpdateDeleteGet_Tester
{
    private IRepository<DivisionEntity> _repository;
    private IServiceScope _scope;

    [SetUp]
    async public Task Setup()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _scope = webAppFactory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IRepository<DivisionEntity>>();
    }

    [Test]
    // Цикл: Создание - Обновление - Удаление подразделения
    public void AddUpdateDeleteDivisions_result1()
    {
        //arrange
        DivisionEntity content = new DivisionEntity
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
        //act        
        var temp = _repository.Create(content);
        //assert
        Assert.AreEqual("1", temp.ToString());

        //arrange
        content.Address = "NewTestAdress";
        content.Name = "NewTestName";
        content.PIN = "2";
        content.IsActive = false;
        content.Host = "NewTest";
        content.СontractorId = new Guid("08da713e-5b50-4f6e-8f83-98a31a1e675f");
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

    //[Test]
    //async public Task getInstaller_resultOK()
    //{
    //    //arrange
    //    var webAppFactory = new WebApplicationFactory<Program>();
    //    var client = webAppFactory.CreateClient();
    //    client.BaseAddress = new Uri("http://localhost:5247/");
    //    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
    //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    //act 
    //    var responce = await client.GetAsync(client.BaseAddress + "divisions/getInstaller");
    //    Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
    //    //assert
    //    Assert.AreEqual("OK", responce.StatusCode.ToString());
    //}
    //[Test]
    //async public Task getSetup_resultOK()
    //{
    //    //arrange
    //    var webAppFactory = new WebApplicationFactory<Program>();
    //    var client = webAppFactory.CreateClient();
    //    client.BaseAddress = new Uri("http://localhost:5247/");
    //    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
    //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    //act 
    //    var responce = await client.GetAsync(client.BaseAddress + "divisions/getSetup");
    //    Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
    //    //assert
    //    Assert.AreEqual("OK", responce.StatusCode.ToString());
    //}
    [Test]
    async public Task getAllDivisions_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var contractorId = "?ContractorId=08da713e-5b50-4f6e-8f83-98a31a1e675f";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "divisions/getAllDivisions" + contractorId);
        Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }

    [Test]
    async public Task getDivisionById_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var divisionId = "?DivisionId=08da7143-a7b6-45f1-8bf1-2a83babdd41d";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "divisions/getDivisionById" + divisionId);
        Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }
}
