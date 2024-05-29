using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFrameworkServices();
builder.Services.AddSqlServerServices(builder.Configuration);
builder.Services.AddDbRepositories();

var app = builder.Build();

app.ConfigurePipeline(app.Environment);
app.MapControllers();

app.Run();

public partial class Program { }