using System;
using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Data;

public class HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : DbContext(options)
{
    public DbSet<Hotel> Hotels => Set<Hotel>();
    public DbSet<Feature> Features => Set<Feature>();
    public DbSet<Attachment> Attachments => Set<Attachment>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Location> Locations => Set<Location>();
}
