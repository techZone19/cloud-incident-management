var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/events", (EventRequest request) => 
{
     if (string.IsNullOrWhiteSpace(request.Source) ||
        string.IsNullOrWhiteSpace(request.Message))
    {
        return Results.BadRequest("Source and Message are required.");
    }

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
