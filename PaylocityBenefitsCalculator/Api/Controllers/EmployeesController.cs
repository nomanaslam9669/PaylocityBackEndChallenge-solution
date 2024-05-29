using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController(IEmployeeRepository repo, IPayrollService payrollService) : ControllerBase
{

    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id)
    {
        var employee = await repo.GetById(id);

        if (employee is null)
        {
            return NotFound(new ApiResponse<GetEmployeeDto>
            {
                Success = false,
                Message = "Employee not found"
            });
        }

        var employeeDto = new GetEmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Salary = employee.Salary,
            DateOfBirth = DateTime.Parse(employee.DateOfBirth.Date.ToString()),
            Dependents = employee.Dependents.Select(d => new GetDependentDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                DateOfBirth = DateTime.Parse(d.DateOfBirth.Date.ToString()),
            }).ToList()
        };

        var response = new ApiResponse<GetEmployeeDto>
        {
            Data = employeeDto,
            Success = true
        };

        return Ok(response);
    }

    [SwaggerOperation(Summary = "Get all employees")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll()
    {
        var employees = await repo.GetAll();
        var employeesDto = employees.Select(e => new GetEmployeeDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Salary = e.Salary,
            DateOfBirth = e.DateOfBirth,
            Dependents = e.Dependents.Select(d => new GetDependentDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                DateOfBirth = d.DateOfBirth,
                Relationship = d.Relationship
            }).ToList(),
        });
        #region hard-coded-data
        //task: use a more realistic production approach
        //var employees = new List<GetEmployeeDto>
        //{
        //    new()
        //    {
        //        Id = 1,
        //        FirstName = "LeBron",
        //        LastName = "James",
        //        Salary = 75420.99m,
        //        DateOfBirth = new DateTime(1984, 12, 30)
        //    },
        //    new()
        //    {
        //        Id = 2,
        //        FirstName = "Ja",
        //        LastName = "Morant",
        //        Salary = 92365.22m,
        //        DateOfBirth = new DateTime(1999, 8, 10),
        //        Dependents = new List<GetDependentDto>
        //        {
        //            new()
        //            {
        //                Id = 1,
        //                FirstName = "Spouse",
        //                LastName = "Morant",
        //                Relationship = Relationship.Spouse,
        //                DateOfBirth = new DateTime(1998, 3, 3)
        //            },
        //            new()
        //            {
        //                Id = 2,
        //                FirstName = "Child1",
        //                LastName = "Morant",
        //                Relationship = Relationship.Child,
        //                DateOfBirth = new DateTime(2020, 6, 23)
        //            },
        //            new()
        //            {
        //                Id = 3,
        //                FirstName = "Child2",
        //                LastName = "Morant",
        //                Relationship = Relationship.Child,
        //                DateOfBirth = new DateTime(2021, 5, 18)
        //            }
        //        }
        //    },
        //    new()
        //    {
        //        Id = 3,
        //        FirstName = "Michael",
        //        LastName = "Jordan",
        //        Salary = 143211.12m,
        //        DateOfBirth = new DateTime(1963, 2, 17),
        //        Dependents = new List<GetDependentDto>
        //        {
        //            new()
        //            {
        //                Id = 4,
        //                FirstName = "DP",
        //                LastName = "Jordan",
        //                Relationship = Relationship.DomesticPartner,
        //                DateOfBirth = new DateTime(1974, 1, 2)
        //            }
        //        }
        //    }
        //};
        #endregion

        var result = new ApiResponse<List<GetEmployeeDto>>
        {
            Data = employeesDto.ToList(),
            Success = true
        };

        return result;
    }

    [SwaggerOperation(Summary = "Add new employee")]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<string>>> AddEmployee(Employee employee)
    {
        var spouseCount = employee?.Dependents?.Count(d => d.Relationship == Relationship.Spouse);
        var domesticPartnerCount = employee?.Dependents?.Count(d => d.Relationship == Relationship.DomesticPartner);

        if (spouseCount > 1 || domesticPartnerCount > 1 || (spouseCount > 0 && domesticPartnerCount > 0))
        {

            return BadRequest(
                new ApiResponse<string>
                {
                    Error = "An employee can only have one spouse or domestic partner.",
                    Success = false,
                }
            );
        }

        await repo.Add(employee);

        var response = new ApiResponse<string>
        {
            Data = "Created",
            Success = true,
        };

        return response;
    }

    [SwaggerOperation(Summary = "Calculate paycheck for employee")]
    [HttpGet("paycheck/{id}")]
    public async Task<ActionResult<ApiResponse<string>>> CalculatePaycheck(int id)
    {
        var employee = await repo.GetById(id);

        if (employee is null) return new ApiResponse<string> { Error = "Employee not found", Success = false };

        var employeePaycheque = payrollService.CalculatePaycheck(employee);
        var response = new ApiResponse<string>
        {
            Data = $"{employeePaycheque:F2}",
            Success = true,
        };

        return Ok(response);
    }
}
