using HotelBooking.Api.Endpoints;
using HotelBooking.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.RegisterDependencies();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.RegisterEndpoints();
app.Run();
