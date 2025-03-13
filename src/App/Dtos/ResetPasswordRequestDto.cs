using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.src.App.Dtos;

public record class ResetPasswordRequestDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Token { get; set; }

    [Required]
    [EmailAddress]
    public required string NewPassword { get; set; }
}
