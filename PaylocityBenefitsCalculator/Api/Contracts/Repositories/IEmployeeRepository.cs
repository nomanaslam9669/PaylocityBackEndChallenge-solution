using Api.Models;

namespace Api.Contracts.Repositories;

public interface IEmployeeRepository
{
    Task<Employee?> GetById(int? id);
    Task<List<Employee>> GetAll();
    Task Add(Employee employee);
    Task AddRange(ICollection<Employee> employees);
    Task Update(Employee employee);
    Task Delete(Employee employee);
}
