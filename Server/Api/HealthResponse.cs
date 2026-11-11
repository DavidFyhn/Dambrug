using Microsoft.Extensions.Diagnostics.HealthChecks;

public static class HealthResponse
{
    public static string Status(HealthStatus status) =>
        status == HealthStatus.Healthy ? "ok" : "unavailable";
}
