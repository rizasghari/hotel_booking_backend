using HotelBooking.Api.Endpoints;
using HotelBooking.DI;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencies();
builder.ConfigureAuthentication();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.RegisterEndpoints();

app.Run();