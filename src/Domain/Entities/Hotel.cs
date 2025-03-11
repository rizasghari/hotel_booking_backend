using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Domain.Entities;

[Table("Hotels")]
[Comment("Hotels")]
public class Hotel : AuditableEntity
{
    [Column(Order = 1)] [MaxLength(200)] public required string Name { get; set; }
    [Column(Order = 2)] [MaxLength(1000)] public string? Description { get; set; }
    public Location? Location { get; set; } // one-to-one with location 
    [Column("CoverPath", Order = 3)] public string? Cover { get; set; }
    [Column(Order = 4)] public decimal PerNightPrice { get; set; }
    [Column(Order = 5)] public int CategoryId { get; set; }
    public Category Category { get; set; } = null!; // many-to-one with category
    public ICollection<Attachment> Attachments { get; } = [];  // one-to-many with attachment
    public ICollection<Feature> Features { get; } = []; // many-to-many with feature
    public ICollection<Room> Rooms { get; } = []; // one-to-many with room
    [NotMapped] public DateTime LoadedFromDbTime { get; set; }
}
