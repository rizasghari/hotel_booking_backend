using System;

namespace HotelBooking.Domain.Entities;

public class Feature : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Icon { get; set; }
    public ICollection<Hotel> Hotels { get; } = []; // many-to-many with hotel
}
