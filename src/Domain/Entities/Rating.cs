using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.src.Domain.Entities;

[Table("Ratings")]
[Comment("Ratings of bookings")]
public class Rating : AuditableEntity
{
    [Column(Order = 1)] [Range(1, 5)] public int Value { get; set; }
    [Column(Order = 2)] public int BookingId { get; set; }
    public Booking Booking { get; set; } = null!;
    [Column(Order = 3)] public int UserId { get; set; }
    public User User { get; set; } = null!;
}
