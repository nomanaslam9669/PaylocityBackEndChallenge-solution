using Api.Models;

namespace Api.Contracts.Services;

public interface IPayrollService
{
    decimal? CalculatePaycheck(Employee employee);
}
