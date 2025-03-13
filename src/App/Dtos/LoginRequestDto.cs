using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.src.App.Dtos;

public record class LoginRequestDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}
