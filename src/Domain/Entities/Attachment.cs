using System;

namespace HotelBooking.Domain.Entities;

public class Attachment : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string File { get; set; }
    public int HotelId { get; set; } // many-to-one with hotel
     public Hotel Hotel { get; set; } = null!;
}
