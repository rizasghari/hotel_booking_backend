using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelBooking.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Domain.Entities;

[Table("Attachments")]
[Comment("Hotel file attachments")]
public class Attachment : AuditableEntity
{
    [Column(Order = 1)] [MaxLength(100)] public required string Name { get; set; }
    [Column("IconPath", Order = 2)] public required string File { get; set; }
    public int HotelId { get; set; } // many-to-one with hotel
    public Hotel Hotel { get; set; } = null!;
}
