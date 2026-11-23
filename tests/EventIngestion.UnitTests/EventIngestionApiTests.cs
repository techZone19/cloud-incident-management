
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EventIngestion.UnitTests;

public class EventIngestionApiTests
{
    [Fact]
    public async Task PostEvent_WithValidRequest_ReturnsAccepted()
    {
        // Arrange
        await using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient();

        var request = new
        {
            Source = "AzureAppService",
            Severity = "Critical",
            Message = "Database connection timeout"
        };

        // Act
        var response = await client.PostAsJsonAsync("/api/events", request);

        // Assert
        Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
    }


    [Fact]
    public async Task PostEvent_WithEmptySource_ReturnsBadRequest()
    {
        // Arrange
        await using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient();

        var request = new
        {
            Source = "",
            Severity = "Critical",
            Message = "Database connection timeout"
        };

        // Act
        var response = await client.PostAsJsonAsync("/api/events", request);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }


    [Fact]
    public async Task PostEvent_WithEmptyMessage_ReturnsBadRequest()
    {
        // Arrange
        await using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient();

        var request = new
        {
            Source = "AzureAppService",
            Severity = "Critical",
            Message = ""
        };

        // Act
        var response = await client.PostAsJsonAsync("/api/events", request);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
