namespace HotelBooking.App.Dtos;

public record class CategoryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Icon { get; set; }
}
