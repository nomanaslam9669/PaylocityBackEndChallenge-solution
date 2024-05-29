using Api.Dtos.Dependent;
using Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.IntegrationTests;

public class DependentIntegrationTests : IntegrationTest
{
    [Fact]
    //task: make test pass | DONE
    public async Task WhenAskedForAllDependents_ShouldReturnAllDependents()
    {
        var response = await HttpClient.GetAsync("/api/v1/dependents");
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<Dependent>>>(await response.Content.ReadAsStringAsync()).Data;

        Assert.True(104 == apiResponse.Count);
    }

    [Fact]
    //task: make test pass | DONE
    public async Task WhenAskedForADependent_ShouldReturnCorrectDependent()
    {
        var response = await HttpClient.GetAsync("/api/v1/dependents/1");
        var dependent = new GetDependentDto
        {
            Id = 1,
            FirstName = "Aurora",
            LastName = "Young",
            Relationship = Relationship.Spouse,
            DateOfBirth = new DateTime(2010, 5, 24)
        };
        await response.ShouldReturn(HttpStatusCode.OK, dependent);
    }

    [Fact]
    //task: make test pass
    public async Task WhenAskedForANonexistentDependent_ShouldReturn404()
    {
        var response = await HttpClient.GetAsync($"/api/v1/dependents/{int.MinValue}");
        await response.ShouldReturn(HttpStatusCode.NotFound);
    }
}

