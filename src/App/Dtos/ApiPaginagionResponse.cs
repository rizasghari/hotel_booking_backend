using System;

namespace HotelBooking.src.App.Dtos;

public class ApiPaginagionResponse<T>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public int Total { get; set; }
    public T? List { get; set; }
}
