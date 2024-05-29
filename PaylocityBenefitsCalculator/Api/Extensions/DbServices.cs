using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class DbServices
{
    private const string DbConnectionString = "ConnectionStrings:Paylocity";
    public static IServiceCollection AddSqlServerServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<PaylocityDbContext>(opt =>
        {
            opt.UseSqlServer(config[DbConnectionString]);
        });

        return services;
    }
}
