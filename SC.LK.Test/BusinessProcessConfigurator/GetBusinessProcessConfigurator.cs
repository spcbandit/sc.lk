using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.ConfigurationVersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Test.BusinessProcessConfigurator;

internal class GetBusinessProcessConfigurator
{
    private IRepository<BusinessProcess> _repository;
    private IServiceScope _scope;
    private IRepository<BusinessProcess> _repositoryMid;

    [SetUp]
    async public Task Setup()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _scope = (webAppFactory.Services.GetRequiredService<IServiceScopeFactory>()).CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IRepository<BusinessProcess>>();
        _repositoryMid = _scope.ServiceProvider.GetRequiredService<IRepository<BusinessProcess>>();
    }
    //[Test]
    //async public Task getAllBusinessProcessById_resultOK()
    //{
    //    //arrange
    //    var webAppFactory = new WebApplicationFactory<Program>();
    //    var client = webAppFactory.CreateClient();
    //    client.BaseAddress = new Uri("http://localhost:5247/");
    //    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
    //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    //    var bind = _repositoryMid.Create(
    //        new BusinessProcess()
    //        {
    //            BusinessProcessId = new Guid(),
    //            BusinessProcessNumber = 1,
    //        }
    //        );

    //    //act 
    //    var responce = await client.GetAsync(client.BaseAddress + "/businessProcessConfigurator/geAlltBusinessProcessById?ContractorId=00000000-0000-0000-0000-000000000001");
    //    Console.WriteLine(responce.Content.ReadAsStringAsync().Result);

    //    //assert
    //    Assert.AreEqual("OK", responce.StatusCode.ToString());
    //}

    //[Test]
    //async public Task getABusinessProcessById_resultOK()
    //{
    //    //arrange
    //    var webAppFactory = new WebApplicationFactory<Program>();
    //    var client = webAppFactory.CreateClient();
    //    client.BaseAddress = new Uri("http://localhost:5247/");
    //    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
    //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    //act 
    //    var responce = await client.GetAsync(client.BaseAddress + "/businessProcessConfigurator/geAlltBusinessProcessById?ContractorId=00000000-0000-0000-0000-000000000001&BusinessProcessId=059a5e94-82f8-472a-b0bb-b533143b35cf");
    //    Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
    //    //assert
    //    Assert.AreEqual("OK", responce.StatusCode.ToString());
    //}
}
