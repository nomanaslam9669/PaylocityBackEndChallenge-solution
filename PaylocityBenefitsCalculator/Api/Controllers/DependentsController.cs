using Api.Contracts.Repositories;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DependentsController(IDependentRepository repo) : ControllerBase
{
    [SwaggerOperation(Summary = "Get dependent by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetDependentDto>>> Get(int id)
    {
        var dependent = await repo.GetById(id);

        if (dependent is null)
        {
            return NotFound(new ApiResponse<GetEmployeeDto>
            {
                Success = false,
                Message = "Dependent not found"
            });
        }

        var dependentDTO = new GetDependentDto
        {
            Id = dependent.Id,
            FirstName = dependent.FirstName,
            LastName = dependent.LastName,
            DateOfBirth = DateTime.Parse(dependent.DateOfBirth.Date.ToString()),
            Relationship = dependent.Relationship
        };

        var response = new ApiResponse<GetDependentDto>
        {
            Data = dependentDTO,
            Success = true
        };

        return Ok(response);
    }

    [SwaggerOperation(Summary = "Get all dependents")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> GetAll()
    {
        var dependents = await repo.GetAll();
        var dependentsDTOs = dependents.Select(d => new GetDependentDto
        {
            Id = d.Id,
            FirstName = d.FirstName,
            LastName = d.LastName,
            DateOfBirth = DateTime.Parse(d.DateOfBirth.Date.ToString()),
            Relationship = d.Relationship
        });

        var result = new ApiResponse<List<GetDependentDto>>
        {
            Data = dependentsDTOs.ToList(),
            Success = true
        };

        return result;
    }
}
