using System;

namespace HotelBooking.src.App.Dtos;

public class ApiPaginagionResponse<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Count { get; set; }
    public T? Data { get; set; }
}
