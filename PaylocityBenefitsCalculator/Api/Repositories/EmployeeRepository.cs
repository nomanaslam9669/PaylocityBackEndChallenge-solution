using Api.Contracts.Repositories;
using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class EmployeeRepository(PaylocityDbContext context) : IEmployeeRepository
{

    public async Task Add(Employee employee)
    {
        await context.AddAsync(employee);
        await context.SaveChangesAsync();
    }

    public async Task AddRange(ICollection<Employee> employees)
    {
        await context.AddRangeAsync(employees);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Employee employee)
    {
        context.Remove(employee);
        await context.SaveChangesAsync();
    }

    public async Task<List<Employee>> GetAll() => await context.Employees.Include(e => e.Dependents).ToListAsync();

    public async Task<Employee?> GetById(int? id)
    {
        if (id is null) return null;

        return await context.Employees
                            .Include(e => e.Dependents)
                            .FirstOrDefaultAsync(e => e.Id == id.Value);
    }

    public async Task Update(Employee employee)
    {
        if (employee is null) throw new ArgumentNullException(nameof(employee));

        // Attach the employee to the context if it is not already being tracked
        var existingEmployee = await context.Employees.Include(e => e.Dependents).FirstOrDefaultAsync(e => e.Id == employee.Id);

        if (existingEmployee is null) throw new InvalidOperationException("Employee not found.");


        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.DateOfBirth = employee.DateOfBirth;


        context.Dependents.RemoveRange(existingEmployee.Dependents);

        foreach (var dependent in employee.Dependents)
        {
            existingEmployee.Dependents.Add(new()
            {
                FirstName = dependent.FirstName,
                LastName = dependent.LastName,
                DateOfBirth = dependent.DateOfBirth,
                Relationship = dependent.Relationship,
                EmployeeId = existingEmployee.Id
            });
        }

        context.Entry(existingEmployee).State = EntityState.Modified;

        await context.SaveChangesAsync();
    }
}
