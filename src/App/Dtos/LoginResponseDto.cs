namespace HotelBooking.src.App.Dtos;

public record class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
}
