using System;
using HotelBooking.Infrastructure.Data;

namespace HotelBooking.DI;

public static class DI
{
    public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder) {

        // Sqlite Database
        var connString = builder.Configuration.GetConnectionString("HotelBooking");
        builder.Services.AddSqlite<HotelBookingDbContext>(connString);

        return builder;
    }
}
