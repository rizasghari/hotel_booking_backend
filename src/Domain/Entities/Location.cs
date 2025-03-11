using System;

namespace HotelBooking.Domain.Entities;

public class Location : BaseEntity
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public required string Address { get; set; }
    public required string Country { get; set; }
    public required string City { get; set; }
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!; // one-to-one with hotel
}
