using System;

namespace HotelBooking.Domain.Entities;

public class Category : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Icon { get; set; }
    public ICollection<Hotel> Hotels { get; } = [];  // one-to-many with hotel
}
