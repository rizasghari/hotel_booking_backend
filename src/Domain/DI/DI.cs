using System;
using System.Text;
using HotelBooking.App.IServices;
using HotelBooking.App.Services;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Infrastructure.Data;
using HotelBooking.Infrastructure.Repositories;
using HotelBooking.src.App.IServices;
using HotelBooking.src.App.Services;
using HotelBooking.src.Domain.IRepositories;
using HotelBooking.src.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticAssets;
using Microsoft.IdentityModel.Tokens;

namespace HotelBooking.DI;

public static class DI
{
    public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
    {
        // Register the password hasher (from Identity)
        builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        // Sqlite Database
        var connString = builder.Configuration.GetConnectionString("HotelBooking");
        builder.Services.AddSqlite<HotelBookingDbContext>(connString);

        // Repositories
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

        // Services
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

        return builder;
    }

    public static WebApplicationBuilder ConfigureAuthentication(this WebApplicationBuilder builder)
    {
        // Configure JWT Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

        builder.Services.AddAuthorizationBuilder()
            .SetFallbackPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build());

        return builder;
    }
}
