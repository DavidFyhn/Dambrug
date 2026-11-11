using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Tests;

public class HealthResponseTests
{
    [Theory]
    [InlineData(HealthStatus.Healthy, "ok")]
    [InlineData(HealthStatus.Degraded, "unavailable")]
    [InlineData(HealthStatus.Unhealthy, "unavailable")]
    public void StatusMatchesHealthReport(HealthStatus healthStatus, string expected)
    {
        Assert.Equal(expected, HealthResponse.Status(healthStatus));
    }
}
