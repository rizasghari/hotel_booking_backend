using System;

namespace HotelBooking.Domain.Entities;

public class User : BaseEntity
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string PasswordHash { get; set; }
    public string? ProfilePhoto { get; set; }
    public ICollection<Booking> Bookings { get; } = [];
}
