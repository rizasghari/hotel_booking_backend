using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using HotelBooking.src.App.Dtos;
using HotelBooking.src.Domain.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HotelBooking.src.Infrastructure.Repositories;

public class AuthenticationRepository(
    HotelBookingDbContext dbContext,
    IPasswordHasher<User> passwordHasher,
    IConfiguration configuration
) : IAuthenticationRepository
{
    private readonly HotelBookingDbContext _dbContext = dbContext;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    private readonly IConfiguration _configuration = configuration;

    public async Task<OperationResult<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto)
    {
        List<string> errors = [];

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginRequestDto.Email);
        if (user == null)
        {
            errors.Add("User not found.");
            return new OperationResult<LoginResponseDto>
            {
                IsSuccess = false,
                Errors = errors
            };
        }

        var verificationResult = _passwordHasher.VerifyHashedPassword(user!, user!.PasswordHash, loginRequestDto.Password);
        if (verificationResult == PasswordVerificationResult.Failed)
        {
            errors.Add("Invalid password.");
            return new OperationResult<LoginResponseDto>
            {
                IsSuccess = false,
                Errors = errors
            };
        }

        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.Role)
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new OperationResult<LoginResponseDto>
        {
            IsSuccess = true,
            Data = new LoginResponseDto
            {
                Token = tokenString
            }
        };
    }

    public async Task<OperationResult<User>> SignupAsync(SignupRequestDto signupRequestDto)
    {
        List<string> errors = [];

        // Check if the email already exists
        if (await _dbContext.Users.AnyAsync(u => u.Email == signupRequestDto.Email))
        {
            errors.Add("Email already exists");
        }

        // Check if the phone number already exists
        if (await _dbContext.Users.AnyAsync(u => u.PhoneNumber == signupRequestDto.PhoneNumber))
        {
            errors.Add("Phone number already exists");
        }

        // Create the user
        var user = new User
        {
            FirstName = signupRequestDto.FirstName,
            LastName = signupRequestDto.LastName,
            Email = signupRequestDto.Email,
            PhoneNumber = signupRequestDto.PhoneNumber,
            Role = "User"
        };

        if (errors.Count > 0)
        {
            return new OperationResult<User>
            {
                IsSuccess = false,
                Errors = errors
            };
        }

        try
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, signupRequestDto.Password);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


        return new OperationResult<User>
        {
            IsSuccess = true,
            Data = user
        };

    }
}
