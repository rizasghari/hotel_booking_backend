using System;
using System.ComponentModel.DataAnnotations.Schema;
using HotelBooking.Domain.Entities;

namespace HotelBooking.src.Domain.Entities;

public class UserFavoriteHotel : AuditableEntity
{
    [Column(Order = 1)] public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    [Column(Order = 2)] public int HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;
}
