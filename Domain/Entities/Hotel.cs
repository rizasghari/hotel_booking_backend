using System;

namespace HotelBooking.Domain.Entities;

public class Hotel : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public Location? Location { get; set; } // one-to-one with location 
    public string? Cover { get; set; }
    public decimal PerNightPrice { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!; // many-to-one with category
    public ICollection<Attachment> Attachments { get; } = [];  // one-to-many with attachment
    public ICollection<Feature> Features { get; } = []; // many-to-many with feature
    public ICollection<Room> Rooms { get; } = []; // one-to-many with room
}
