using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.src.App.Dtos;

public record class ForgetPasswordRequestDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
}
