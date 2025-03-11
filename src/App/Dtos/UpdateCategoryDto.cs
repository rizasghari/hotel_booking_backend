using System.ComponentModel.DataAnnotations;

namespace HotelBooking.App.Dtos;

public record class UpdateCategoryDto
{
    [Required]
    [StringLength(100)]
    public required string Name { get; init; }
}
