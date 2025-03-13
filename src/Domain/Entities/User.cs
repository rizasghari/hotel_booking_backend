using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelBooking.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Domain.Entities;

[Table("Users")]
[Comment("Registered users")]
public class User : AuditableEntity
{
    [Column(Order = 1)][MaxLength(100)] public required string FirstName { get; set; }
    [Column(Order = 2)][MaxLength(100)] public required string LastName { get; set; }
    [Column(Order = 3)][MaxLength(200)][EmailAddress] public required string Email { get; set; }
    [Column(Order = 4)][Phone] public required string PhoneNumber { get; set; }
    [Column("ProfilePhotoPath", Order = 5)] public string? ProfilePhoto { get; set; }
    [Column(Order = 6)] public string PasswordHash { get; set; } = string.Empty;
    [Column(Order = 7)] public string Role { get; set; } = "User"; // Role can be "Admin", "HotelManager", or "User"
    [Column(Order = 8)] public string? ResetToken { get; set; }  // For password recovery
    [Column(Order = 9)] public DateTime? ResetTokenExpires { get; set; }
    public ICollection<Booking> Bookings { get; } = [];
    public ICollection<Rating> Ratings { get; set; } = [];
    public ICollection<UserFavoriteHotel> FavoriteHotels { get; set; } = [];

}
