using System;

namespace HotelBooking.Domain.Entities;

public class Attachment : BaseEntity
{
    public int Id { get; set; }
    public string File { get; set; } = string.Empty;
    public int HotelId { get; set; } // many-to-one with hotel / attachment is dependent (child)
}
