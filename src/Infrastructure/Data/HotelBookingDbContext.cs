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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Hotel one-to-one Location
        modelBuilder.Entity<Hotel>()
            .HasOne(h => h.Location)
            .WithOne(l => l.Hotel)
            .HasForeignKey<Location>(l => l.HotelId)
            .IsRequired(true); // Every Location must be related to a Hotel

        // Hotel one-to-many Room
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.Rooms)
            .WithOne(r => r.Hotel)
            .HasForeignKey(r => r.HotelId)
            .IsRequired(true); // Every Room must be related to a Hotel

        // Hotel one-to-many Attachment
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.Attachments)
            .WithOne(a => a.Hotel)
            .HasForeignKey(a => a.HotelId)
            .IsRequired(true); // Every Attachment must be related to a Hotel

        // Category one-to-many Hotel
        modelBuilder.Entity<Category>()
            .HasMany(h => h.Hotels)
            .WithOne(h => h.Category)
            .HasForeignKey(h => h.CategoryId)
            .IsRequired(true); // Every Hotel must be related to a Category

        // User one-to-many Booking
        modelBuilder.Entity<User>()
            .HasMany(u => u.Bookings)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .IsRequired(true); // Every Booking must be related to a User

        // Room one-to-many Booking
        modelBuilder.Entity<Room>()
            .HasMany(r => r.Bookings)
            .WithOne(b => b.Room)
            .HasForeignKey(b => b.RoomId)
            .IsRequired(true); // Every Booking must be related to a Room (of a Hotel)

        // Hotel many-to-many Feature
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.Features)
            .WithMany(f => f.Hotels);

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditFields()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Property(e => e.CreatedAt).IsModified = false;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Deleted:
                    // Soft delete
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    break;
            }
        }
    }
}
