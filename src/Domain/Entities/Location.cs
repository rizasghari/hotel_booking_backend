using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Domain.Entities;

[Table("Locations")]
[Comment("Locations of hotels")]
public class Location : AuditableEntity
{
    [Column(Order = 1)] public double Latitude { get; set; }
    [Column(Order = 2)] public double Longitude { get; set; }
    [Column(Order = 3)] [MaxLength(500)] public required string Address { get; set; }
    [Column(Order = 4)] [MaxLength(100)] public required string Country { get; set; }
    [Column(Order = 5)] [MaxLength(100)] public required string City { get; set; }
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!; // one-to-one with hotel
}
