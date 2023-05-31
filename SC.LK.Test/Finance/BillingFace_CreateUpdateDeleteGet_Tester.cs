using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Handlers.Terminals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SC.LK.Test.Finance;

internal class BillingFace_CreateUpdateDeleteGet_Tester
{
    private IRepository<BillingFaceEntity> _repository;
    private IRepository<PaymentSystemEntity> _paymentSystemRepository;
    private IServiceScope _scope;

    [SetUp]
    public void Setup()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _scope = webAppFactory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IRepository<BillingFaceEntity>>();
        //_paymentSystemRepository = _scope.ServiceProvider.GetRequiredService<IRepository<PaymentSystemEntity>>;
        
    }

    //[Test]
    //// Цикл: Создание - Обновление - Удаление роли
    //public void CreateUpdateDeleteBillingFace_result1()
    //{
    //    //arrange
    //    PaymentSystemEntity payment = new PaymentSystemEntity
    //    {
    //        Id = new Guid("08dade84-ddc1-4ded-8979-aa3e2972f2f8"),
    //        Name = "TestName",
    //        Token = "TestToken",
    //        MainUrl = "TestUrl",
    //        Updated = DateTime.Now
    //    };
    //    BillingFaceEntity content = new BillingFaceEntity
    //    {
    //        Id = new Guid("08dade84-ddb6-4318-8b5c-ef7640966826"),
    //        Name = "TestName",
    //        INN = "0000000000",
    //        KPP = "0",
    //        PaymentSystem = payment,
    //        СontractorId = new Guid("08da6ee6-00a6-4da4-8c9a-d050b3127e14"),
    //        Updated = DateTime.Now
    //    };
    //    //act        
    //    var temp = _repository.Create(content);
    //    Console.WriteLine(temp.ToString());
    //    //assert
    //    Assert.AreEqual("2", temp.ToString());

    //    //arrange
    //    content.Name = "NewTestName";
    //    content.INN = "9999999999";
    //    content.KPP = "9";
    //    content.PaymentSystem = payment;
    //    content.СontractorId = new Guid("08da6ee6-00a6-4da4-8c9a-d050b3127e14");
    //    content.Updated = DateTime.Now;
    //    //act   
    //    temp = _repository.Update(content);
    //    //assert
    //    Assert.AreEqual("1", temp.ToString());

    //    //act   
    //    temp = _repository.Remove(content);
    //    temp = _paymentSystemRepository.Remove(payment);

    //    //assert
    //    Assert.AreEqual("1", temp.ToString());
    //}

    [Test]
    async public Task GetAllBillingFace_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var contractorId = "?ContractorId=08da8734-a9ee-44b8-8c85-7022d8d874bd";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "finance/getAllBillingFace" + contractorId);
        Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }

    [Test]
    async public Task GetBillingFaceById_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var billingFaceId = "?BillingFaceId=08da8734-a9f5-4809-82f0-f77646e8a40f";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "finance/getBillingFaceById" + billingFaceId);
        Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }
}
