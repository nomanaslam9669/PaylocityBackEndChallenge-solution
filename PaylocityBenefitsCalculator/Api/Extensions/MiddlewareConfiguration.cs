namespace Api.Extensions;

public static class MiddlewareConfiguration
{
    public static IApplicationBuilder ConfigurePipeline(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Benefit Cost Calculation Api v1");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        return app;
    }
}
