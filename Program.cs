using HotelBooking.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.RegisterDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hi there!");

app.Run();
