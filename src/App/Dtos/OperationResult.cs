using System;

namespace HotelBooking.src.App.Dtos;

public class OperationResult<T>
{
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; set; } = [];
    public T? Data { get; set; }
}
