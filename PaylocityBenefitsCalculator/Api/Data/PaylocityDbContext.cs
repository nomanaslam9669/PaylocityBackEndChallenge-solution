using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Api.Data;

public class PaylocityDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Dependent> Dependents { get; set; }


    private List<string> Names { get; set; } = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(@"./Data/names.json"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(GenerateEmployees());
        modelBuilder.Entity<Dependent>().HasData(GenerateDependents());
    }

    private List<Employee> GenerateEmployees()
    {
        var employees = new List<Employee>();
        var random = new Random();

        for (int i = 1; i <= 30; i++)
        {
            employees.Add(new Employee
            {
                Id = i,
                FirstName = Names[i].Split(" ")[0],
                LastName = Names[i].Split(" ")[1],
                Salary = random.Next(50000, 150000),
                DateOfBirth = DateTime.Now.AddYears(-random.Next(25, 65))
            });
        }

        return employees;
    }

    private List<Dependent> GenerateDependents()
    {
        var dependents = new List<Dependent>();
        var random = new Random();
        int id = 1;

        for (int i = 1; i <= 30; i++)
        {
            int numberOfDependents = random.Next(2, 6);
            for (int j = 0; j < numberOfDependents; j++)
            {
                dependents.Add(new Dependent
                {
                    Id = id++,
                    FirstName = Names[i + j + 30].Split(" ")[0],
                    LastName = Names[i + j + 30].Split(" ")[1],
                    DateOfBirth = DateTime.Now.AddYears(-random.Next(0, 25)),
                    Relationship = (Relationship)random.Next(0, Enum.GetValues(typeof(Relationship)).Length),
                    EmployeeId = i
                });
            }
        }

        return dependents;
    }
}
