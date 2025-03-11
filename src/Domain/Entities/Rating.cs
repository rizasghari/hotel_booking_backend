using System;
using System.ComponentModel.DataAnnotations.Schema;
using HotelBooking.Domain.Entities;

namespace HotelBooking.src.Domain.Entities;

public class Rating : AuditableEntity
{
    [Column(Order = 1)] public int Value { get; set; }
    [Column(Order = 2)] public int BookingId { get; set; }
    public Booking Booking { get; set; } = null!;
    [Column(Order = 3)] public int UserId { get; set; }
    public User User { get; set; } = null!;
}
