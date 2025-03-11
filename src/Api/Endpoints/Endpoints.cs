using System;
using HotelBooking.App.Dtos;
using HotelBooking.App.IServices;
using HotelBooking.App.Mappings;
using HotelBooking.src.App.Dtos;
using HotelBooking.src.Domain.Exceptions;

namespace HotelBooking.Api.Endpoints;

public static class Endpoints
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {

        var v1 = app.MapGroup("/v1");

        /* __________________ CATEGORIES __________________ */

        var category = v1.MapGroup("/categories");

        // GET ALL
        category.MapGet("/", async (ICategoryService categoryService) =>
        {
            var categories = await categoryService.GetAllAsync();
            return Results.Ok(categories);
        });

        // GET BY ID
        category.MapGet("/{id}", async (int id, ICategoryService categoryService) =>
        {
            var category = await categoryService.GetByIdAsync(id);
            return category is null ? Results.NotFound() : Results.Ok(category);
        });

        // CREATE
        category.MapPost("/", async (CreateCategoryDto createCategoryDto, ICategoryService categoryService) =>
        {
            var createdCategory = await categoryService.AddAsync(createCategoryDto);
            return Results.Created($"/v1/category/{createdCategory.Id}", createdCategory.ToCategoryResponseDto());
        }).WithParameterValidation();

        // UPDATE
        category.MapPut("/{id}", async (int id, UpdateCategoryDto updateCategoryDto, ICategoryService categoryService) =>
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

        /* __________________ HOTELS __________________ */

        return app;
    }
}
