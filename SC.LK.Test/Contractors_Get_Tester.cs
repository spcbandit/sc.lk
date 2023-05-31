using Microsoft.AspNetCore.Mvc.Testing;
using Org.BouncyCastle.Bcpg;
using SC.LK.Application.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Test;

internal class Contractors_Get_Tester
{
    [Test]
    async public Task GetContractors_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var userId = "?UserId=08da6ee6-02cc-4bcd-85c9-93bf8a9e387a";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "contractor/getContractors" + userId);
        //Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }

    [Test]
    async public Task GetChildContragents_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var mainContractorId = "?MainContractorId=08da713e-5b50-4f6e-8f83-98a31a1e675f";
        var userId = "&UserId=08da713e-5b7a-4b87-8267-cbdb793fa002";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "contractor/getChildContragents" + mainContractorId + userId);
        //Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }
    
    [Test]
    async public Task GetContractorNameById_resultOK()
    {
        //arrange
        var webAppFactory = new WebApplicationFactory<Program>();
        var client = webAppFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5247/");
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var contractorId = "?ContractorId=08da6eea-bb78-4607-8a05-cf30107bdda7";
        //act 
        var responce = await client.GetAsync(client.BaseAddress + "contractor/getContractorNameById" + contractorId);
        Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
        //assert
        Assert.AreEqual("OK", responce.StatusCode.ToString());
    }

    //[Test]
    //async public Task GetPinCodeByContragentId_resultOK()
    //{
    //    //arrange
    //    var webAppFactory = new WebApplicationFactory<Program>();
    //    var client = webAppFactory.CreateClient();
    //    client.BaseAddress = new Uri("http://localhost:5247");
    //    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
    //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    var contractorId = "?KontrAgentId=08da6ee6-00a6-4da4-8c9a-d050b3127e14";
        
    //    //act 
    //    var responce = await client.GetAsync(client.BaseAddress + "/contractor/getPinCodeByContragentId" + contractorId);
    //    Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
    //    //assert
    //    Assert.AreEqual("OK", responce.StatusCode.ToString());
    //}
}
