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

internal class Ticket_CreateUpdateDeleteGet_Tester
{
    private IRepository<TicketEntity> _repository;
    private IServiceScope _scope;

    [SetUp]
    async public Task Setup()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _scope = webAppFactory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IRepository<TicketEntity>>();
    }

    [Test]
    async public Task CreateUpdateDeleteTicket_resultOK()
    {
        //arrange
        TicketEntity content = new TicketEntity
        {
            Id = new Guid("08daadc6-a774-4b18-86a3-eed249385cb5"),
            TicketType = 0,
            FromUser = new Guid("08dabdcd-ada2-4194-8400-b585874a8f4e"),
            FromContragent = new Guid("08dabdcd-acfe-4cbc-8957-8a821d6e9111"),
            Message = "Test",
            Updated = DateTime.Now,
        };
        //act        
        var temp = _repository.Create(content);
        //assert
        Assert.AreEqual("1", temp.ToString());

        //arrange
        content.TicketType = 0;
        content.Message = "2";
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
    async public Task getAllTickets_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var contractorId = "?ContractorId=08da6ee6-00a6-4da4-8c9a-d050b3127e14";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "tickets/getAllTickets" + contractorId);
        //Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }
}
