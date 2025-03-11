namespace HotelBooking.src.App.Dtos;

public class ApiResponse<T>
{
    public bool Successful { get; set; }
    public T? Data { get; set; }
    public List<string> Errors { get; set; } = [];
}

