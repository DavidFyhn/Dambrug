using DataAccess;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();

var connectionString = builder.Configuration.GetConnectionString("Dambrug");
if (!string.IsNullOrWhiteSpace(connectionString))
{
    builder.Services.AddSingleton(_ => Postgres.CreateDataSource(connectionString));
}

var app = builder.Build();

app.MapHealthChecks("/api/health", new HealthCheckOptions
{
    ResponseWriter = (context, report) =>
        context.Response.WriteAsJsonAsync(new { status = HealthResponse.Status(report.Status) })
});

app.Run();
