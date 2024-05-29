using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.IntegrationTests;

public class EmployeeIntegrationTests : IntegrationTest
{
    [Fact]
    public async Task WhenAskedForAllEmployees_ShouldReturnAllEmployees()
    {
        var response = await HttpClient.GetAsync("/api/v1/employees");
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<Employee>>>(await response.Content.ReadAsStringAsync()).Data;

        Assert.True(30 == apiResponse.Count);
    }

    [Fact]
    //task: make test pass | DONE
    public async Task WhenAskedForAnEmployee_ShouldReturnCorrectEmployee()
    {
        var response = await HttpClient.GetAsync("/api/v1/employees/1");
        var employee = new GetEmployeeDto
        {
            Id = 1,
            FirstName = "Charlotte",
            LastName = "Johnson",
            Salary = 103027.00m,
            DateOfBirth = new DateTime(1960, 5, 24),
            Dependents = new List<GetDependentDto>
            {
                new()
                {
                    Id = 1,
                    FirstName = "Aurora",
                    LastName = "Young",
                    DateOfBirth= new DateTime(2010, 5, 24),
                    Relationship = Relationship.Spouse,
                },
                new()
                {
                    Id = 2,
                    FirstName = "Carter",
                    LastName = "Allen",
                    DateOfBirth= new DateTime(2013, 5, 24),
                    Relationship = Relationship.None,
                },
                new()
                {
                    Id = 3,
                    FirstName = "Zoey",
                    LastName = "King",
                    DateOfBirth= new DateTime(2003, 5, 24),
                    Relationship = Relationship.Child,
                },
            }
        };
        await response.ShouldReturn(HttpStatusCode.OK, employee);
    }

    [Fact]
    //task: make test pass | DONE
    public async Task WhenAskedForANonexistentEmployee_ShouldReturn404()
    {
        var response = await HttpClient.GetAsync($"/api/v1/employees/{int.MinValue}");
        await response.ShouldReturn(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task WhenAskedForPaycheck_ShouldReturnCorrectAmount()
    {
        var amount = "2591.02";
        var response = await HttpClient.GetAsync($"/api/v1/employees/paycheck/1");
        var responseString = await response.Content.ReadAsStringAsync();
        var jsonResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(responseString);

        Assert.NotNull(jsonResponse);
        Assert.Equal(amount, jsonResponse.Data);
    }
}

