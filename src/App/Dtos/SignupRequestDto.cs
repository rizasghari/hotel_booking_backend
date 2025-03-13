using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.src.App.Dtos;

public record class SignupRequestDto
{
    [Required]
    [StringLength(100)]
    public required string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public required string LastName { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [Phone]
    public required string PhoneNumber { get; set; }

    [Required]
    public required string Password { get; set; }
}
