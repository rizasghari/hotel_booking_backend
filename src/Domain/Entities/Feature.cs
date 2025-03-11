using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Domain.Entities;

[Table("Features")]
[Comment("Hotel features")]
public class Feature : AuditableEntity
{
    [Column(Order = 1)][MaxLength(100)] public required string Name { get; set; }
    [Column("IconPath", Order = 2)] public string? Icon { get; set; }
    public ICollection<Hotel> Hotels { get; } = []; // many-to-many with hotel
}
