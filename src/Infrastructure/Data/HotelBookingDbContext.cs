using System;
using HotelBooking.Domain.Entities;
using HotelBooking.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Data;

public class HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : DbContext(options)
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User unique email
        modelBuilder.Entity<User>()
            .HasAlternateKey(u => u.Email);

        // Unique rating per booking and user.
        modelBuilder.Entity<Rating>()
            .HasAlternateKey(r => new { r.BookingId, r.UserId });

        // Booking one-to-many Rating
        modelBuilder.Entity<Rating>()
            .HasOne(r => r.Booking)
            .WithMany(b => b.Ratings)
            .HasForeignKey(r => r.BookingId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);

        // User one-to-many Rating
        modelBuilder.Entity<Rating>()
            .HasOne(r => r.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(r => r.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);

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
        var entries = ChangeTracker.Entries<AuditableEntity>();

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
