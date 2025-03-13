using System;
using HotelBooking.Domain.Entities;
using HotelBooking.src.App.Dtos;

namespace HotelBooking.src.App.IServices;

public interface IAuthenticationService
{
    Task<OperationResult<User>> SignupAsync(SignupRequestDto signupRequestDto);
    Task<OperationResult<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto);
}
