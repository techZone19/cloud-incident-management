using System;

namespace EventIngestion.Api.Services;

public interface IEventIngestionService
{
 Guid ReceiveEvent(string source, string severity, string message);

}
