using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Domain.Entities;

[Table("Rooms")]
[Comment("Rooms of hotels")]
public class Room : AuditableEntity
{
    [Column(Order = 1)] public required string Number { get; set; }
    [Column(Order = 2)] public int Capacity { get; set; }
    [Column(Order = 3)] public int HotelId { get; set; } // many-to-one with hotel
    public Hotel Hotel { get; set; } = null!;
    public ICollection<Booking> Bookings { get; } = []; // one-to-many with booking
}
