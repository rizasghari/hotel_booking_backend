using System;

namespace HotelBooking.App.Dtos;

public class CategoryResponseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Icon { get; set; }
}
