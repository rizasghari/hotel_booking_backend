namespace HotelBooking.src.App.Dtos;

public record class SignupResponseDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }
}
