using System;

namespace HotelBooking.Domain.Entities;

public class Hotel : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Location? Location { get; set; } // one-to-one with location 
    public string? Cover { get; set; } = string.Empty;
    public decimal PerNightPrice { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!; // many-to-one with category
    public ICollection<Attachment> Attachments { get; } = [];  // one-to-many with attachment
    public ICollection<Feature> Features { get; } = []; // many-to-many with feature
}
