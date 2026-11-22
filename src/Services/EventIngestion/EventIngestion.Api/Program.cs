using Serilog;
using EventIngestion.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services);
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IEventIngestionService, EventIngestionService>();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseSerilogRequestLogging();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");
app.MapPost("/api/events", (EventRequest request, IEventIngestionService eventService) => 
{
     if (string.IsNullOrWhiteSpace(request.Source) ||
        string.IsNullOrWhiteSpace(request.Message))
    {
        return Results.BadRequest("Source and Message are required.");
    }

    var eventId = eventService.ReceiveEvent(
        request.Source,
        request.Severity,
        request.Message);

    return Results.Accepted(
        value: new 
        { 
             EventId = Guid.NewGuid(),
            Status = "Received",
            request.Source,
            request.Severity,
            request.Message 
        });
     
 });


app.Run();

public record EventRequest(
    string Source,
    string Severity,
    string Message);
