
using EventIngestion.Api.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace EventIngestion.UnitTests;

public class EventIngestionServiceTests
{
    [Fact]
    public void ReceiveEvent_ShouldReturnValidEventId()
    {
        // Arrange
        var logger = NullLogger<EventIngestionService>.Instance;
        var service = new EventIngestionService(logger);

        // Act
        Guid eventId = service.ReceiveEvent(
            "AzureAppService",
            "Critical",
            "Database connection timeout");

        // Assert
        Assert.NotEqual(Guid.Empty, eventId);
    }


    [Fact]
    public void ReceiveEvent_ShouldGenerateUniqueIds_ForDifferentEvents()
    {
        // Arrange
        var logger = NullLogger<EventIngestionService>.Instance;
        var service = new EventIngestionService(logger);

        // Act
        Guid firstEventId = service.ReceiveEvent(
            "AzureAppService",
            "Critical",
            "Database connection timeout");

        Guid secondEventId = service.ReceiveEvent(
            "RabbitMQ",
            "Warning",
            "Message queue is unavailable");

        // Assert
        Assert.NotEqual(firstEventId, secondEventId);
    }

}
