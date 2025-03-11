using System;
using HotelBooking.App.IServices;
using HotelBooking.App.Services;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Infrastructure.Data;
using HotelBooking.Infrastructure.Repositories;

namespace HotelBooking.DI;

public static class DI
{
    public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder) {

        // Sqlite Database
        var connString = builder.Configuration.GetConnectionString("HotelBooking");
        builder.Services.AddSqlite<HotelBookingDbContext>(connString);

        // Repositories
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

        // Services
        builder.Services.AddScoped<ICategoryService, CategoryService>();

        return builder;
    }
}
