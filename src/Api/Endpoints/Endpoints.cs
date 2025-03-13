using System;
using HotelBooking.App.Dtos;
using HotelBooking.App.IServices;
using HotelBooking.src.App.Mappings;
using HotelBooking.src.Api.Filters;
using HotelBooking.src.App.Dtos;
using HotelBooking.src.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.src.App.IServices;

namespace HotelBooking.Api.Endpoints;

public static class Endpoints
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {

        var v1 = app.MapGroup("/v1");

        /* __________________ AUTHENTICATION __________________ */

        var authentication = v1.MapGroup("/auth");

        authentication.AllowAnonymous();

        // SIGNUP
        authentication.MapPost("/signup", async (
            SignupRequestDto createUserDto,
            IAuthenticationService authenticationService
        ) =>
        {
            var result = await authenticationService.SignupAsync(createUserDto);

            if (result.IsSuccess)
            {
                return Results.Ok(new ApiResponse<SignupResponseDto>
                {
                    Successful = true,
                    Data = result.Data?.ToSignupResponseDto()
                });
            }
            else
            {
                return Results.BadRequest(new ApiResponse<SignupRequestDto>
                {
                    Successful = false,
                    Errors = result.Errors
                });
            }
        });

        // LOGIN
        authentication.MapPost("/login", async (
            LoginRequestDto loginRequestDto,
            IAuthenticationService authenticationService
        ) =>
        {
            var result = await authenticationService.LoginAsync(loginRequestDto);

            if (result.IsSuccess)
            {
                return Results.Ok(new ApiResponse<LoginResponseDto>
                {
                    Successful = true,
                    Data = result.Data
                });
            }
            else
            {
                return Results.BadRequest(new ApiResponse<LoginRequestDto>
                {
                    Successful = false,
                    Errors = result.Errors
                });
            }
        });

        /* #################### Admin #################### */

        var admin = v1.MapGroup("/admin")
            .RequireAuthorization(policy => policy.RequireRole("Admin")); ;

        /* __________________ CATEGORIES __________________ */

        var adminCategories = admin.MapGroup("/categories");

        // GET ALL
        adminCategories.MapGet("/", async (
            ICategoryService categoryService,
            [FromQuery(Name = "page")] int page = 1,
            [FromQuery(Name = "size")] int size = 10,
            [FromQuery(Name = "desc")] bool desc = false,
            [FromQuery(Name = "search")] string search = ""
        ) =>
        {
            (IEnumerable<CategoryDto> categories, int total) = await categoryService.GetAllAsync(page, size, desc, search);
            return Results.Ok(new ApiResponse<ApiPaginagionResponse<IEnumerable<CategoryDto>>>
            {
                Successful = true,
                Data = new ApiPaginagionResponse<IEnumerable<CategoryDto>>
                {
                    Page = page,
                    Size = size,
                    Total = total,
                    List = categories
                }
            });
        });

        // GET BY ID
        adminCategories.MapGet("/{id}", async (int id, ICategoryService categoryService) =>
        {
            var category = await categoryService.GetByIdAsync(id);
            return category is null ? Results.NotFound(new ApiResponse<dynamic>
            {
                Successful = false,
                Errors = [
                    "Category not found"
                ]
            }) : Results.Ok(new ApiResponse<CategoryDto>
            {
                Successful = true,
                Data = category
            });
        });

        // CREATE
        adminCategories.MapPost("/", async (CreateCategoryDto createCategoryDto, ICategoryService categoryService) =>
        {
            var createdCategory = await categoryService.AddAsync(createCategoryDto);
            return Results.Created($"/v1/category/{createdCategory.Id}", createdCategory.ToCategoryResponseDto());
        }).AddEndpointFilter<CreateCategoryFilter>();

        // UPDATE
        adminCategories.MapPut("/{id}", async (int id, UpdateCategoryDto updateCategoryDto, ICategoryService categoryService) =>
        {
            try
            {
                await categoryService.UpdateCategoryAsync(id, updateCategoryDto);
                return Results.NoContent();
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(new ApiResponse<dynamic>
                {
                    Successful = false,
                    Errors = [
                        e.Message
                    ]
                });
            }
            catch (Exception e)
            {
                return Results.BadRequest(new ApiResponse<dynamic>
                {
                    Successful = false,
                    Errors = [
                        e.Message
                    ]
                });
            }
        });

        adminCategories.MapDelete("/{id}", async (int id, ICategoryService categoryService) =>
        {
            try
            {
                await categoryService.DeleteAsync(id);
                return Results.NoContent();
            }
            catch (Exception e)
            {
                return Results.BadRequest(new ApiResponse<dynamic>
                {
                    Successful = false,
                    Errors = [
                        e.Message
                    ]
                });
            }
        });

        /* __________________ HOTELS __________________ */

        return app;
    }
}
