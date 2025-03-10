using System;

namespace HotelBooking.Domain.Entities;

public class Room : BaseEntity
{
    public int Id { get; set; }
    public required string Number { get; set; }
    public int Capacity { get; set; }
    public int HotelId { get; set; } // many-to-one with hotel
    public Hotel Hotel { get; set; } = null!;
    public ICollection<Booking> Bookings { get; } = []; // one-to-many with booking
}
