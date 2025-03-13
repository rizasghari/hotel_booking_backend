using System;
using HotelBooking.Domain.Entities;
using HotelBooking.src.App.Dtos;
using HotelBooking.src.App.IServices;
using HotelBooking.src.Domain.IRepositories;

namespace HotelBooking.src.App.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository _authenticationRepository;

    public AuthenticationService(IAuthenticationRepository authenticationRepository)
    {
        _authenticationRepository = authenticationRepository;
    }

    public async Task<OperationResult<User>> SignupAsync(SignupRequestDto signupRequestDto)
    {
        return await _authenticationRepository.SignupAsync(signupRequestDto);
    }

    public async Task<OperationResult<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto)
    {
        return await _authenticationRepository.LoginAsync(loginRequestDto);
    }
}
