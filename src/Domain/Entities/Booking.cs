using System;

namespace HotelBooking.Domain.Entities;

public class Booking : BaseEntity
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public BookingStatus BookingStatus { get; set; }
}

public enum BookingStatus
{
    Pending,
    Confirmed,
    Canceled,
    Completed,
}
