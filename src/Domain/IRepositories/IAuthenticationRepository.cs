using System;
using HotelBooking.Domain.Entities;
using HotelBooking.src.App.Dtos;

namespace HotelBooking.src.Domain.IRepositories;

public interface IAuthenticationRepository
{
    Task<OperationResult<User>> SignupAsync(SignupRequestDto signupRequestDto); 
    Task<OperationResult<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto);
}