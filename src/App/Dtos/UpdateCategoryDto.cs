namespace HotelBooking.App.Dtos;

public record class UpdateCategoryDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
}
