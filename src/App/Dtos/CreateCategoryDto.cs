namespace HotelBooking.App.Dtos;

public record class CreateCategoryDto
{
    public required string Name { get; init; }
}
