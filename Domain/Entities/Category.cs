using System;

namespace HotelBooking.Domain.Entities;

public class Category : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public ICollection<Hotel> Hotels { get; } = [];  // one-to-many with hotel
}
