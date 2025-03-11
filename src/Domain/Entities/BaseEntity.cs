using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.src.Domain.Entities;

public class BaseEntity
{
    [Column(Order = 0)]
    public int Id { get; set; }
}
