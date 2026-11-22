namespace EventIngestion.Api.Services;

public sealed class EventIngestionService(
    ILogger<EventIngestionService> logger)
    : IEventIngestionService
{
    public Guid ReceiveEvent(
        string source,
        string severity,
        string message)
    {
        var eventId = Guid.NewGuid();

        logger.LogInformation(
            "Event {EventId} received from {Source} with severity {Severity}",
            eventId,
            source,
            severity);

        return eventId;
    }
}