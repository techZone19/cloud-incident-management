namespace EventIngestion.Api.Contracts;

public sealed record EventRequest(
    string Source,
    string Severity,
    string Message);