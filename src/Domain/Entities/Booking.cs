using System;
using System.ComponentModel.DataAnnotations.Schema;
using HotelBooking.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Domain.Entities;

[Table("Bookings")]
[Comment("Hotel bookings")]
public class Booking : AuditableEntity
{
    [Column(Order = 1)] public int RoomId { get; set; }
    public Room Room { get; set; } = null!;
    [Column(Order = 2)] public int UserId { get; set; }
    public User User { get; set; } = null!;
    [Column(Order = 3)] public DateTime StarDate { get; set; }
    [Column(Order = 4)] public DateTime EndDate { get; set; }
    [Column(Order = 5)] public BookingStatus BookingStatus { get; set; }
    public ICollection<Rating> Ratings { get; set; } = [];
}

public enum BookingStatus
{
    Pending,
    Confirmed,
    Canceled,
    Completed,
}
