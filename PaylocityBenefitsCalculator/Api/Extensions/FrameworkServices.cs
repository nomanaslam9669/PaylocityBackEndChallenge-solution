using Microsoft.OpenApi.Models;

namespace Api.Extensions;

public static class FrameworkServices
{
    public static IServiceCollection AddFrameworkServices(this IServiceCollection services)
    {

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Employee Benefit Cost Calculation Api",
                Description = "Api to support employee benefit cost calculations"
            });
        });

        return services;
    }
}
