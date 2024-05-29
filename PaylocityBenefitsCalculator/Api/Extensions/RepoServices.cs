using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Api.Repositories;
using Api.Services;

namespace Api.Extensions;

public static class RepoServices
{
    public static IServiceCollection AddDbRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDependentRepository, DependentRepository>();
        services.AddScoped<IPayrollService, PayrollService>();

        return services;
    }
}
