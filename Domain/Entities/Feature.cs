using System;

namespace HotelBooking.Domain.Entities;

public class Feature : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; } = string.Empty;
    public ICollection<Hotel> Hotels { get; } = []; // many-to-many with hotel
}
