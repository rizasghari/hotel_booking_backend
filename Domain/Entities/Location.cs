using System;

namespace HotelBooking.Domain.Entities;

public class Location : BaseEntity
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Address { get; set; } = string.Empty;
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!; // one-to-one with hotel
}
