using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Test.Templates
{
    internal class Templates_Get_Tester
    {
        [Test]
        async public Task GetAllTemplates_resultOK()
        {
            //arrange
            var webAppFactory = new WebApplicationFactory<Program>();
            var client = webAppFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5247/");
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var contractorId = "?ContractorId=08dabdd4-2ce2-4667-8693-6917cb95ecac";
            //act 
            var responce = await client.GetAsync(client.BaseAddress + "templates/getAllTemplates" + contractorId);
            Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
            //assert
            Assert.AreEqual("OK", responce.StatusCode.ToString());
        }

        [Test]
        async public Task GetTemplateById_resultOK()
        {
            //arrange
            var webAppFactory = new WebApplicationFactory<Program>();
            var client = webAppFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5247/");
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAxIiwibmJmIjoxNjcwNTY0NjAyLCJleHAiOjE2NzA2NTEwMDIsImlzcyI6IlNDLkxLLkNMSUVOVCIsImF1ZCI6IlNDLkxLLkJBQ0tFTkQifQ.hjNfrNkYYZBoXyrXdqK3tLpjheKhQNdlJWiKRDyfVWg";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var templateId = "?TemplateId=08dabdd4-2ce2-4667-8693-6917cb95ecac";
            //act 
            var responce = await client.GetAsync(client.BaseAddress + "templates/getTemplateById" + templateId);
            Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
            //assert
            Assert.AreEqual("OK", responce.StatusCode.ToString());
        }
    }
}
