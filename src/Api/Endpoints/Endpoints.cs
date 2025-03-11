using System;
using HotelBooking.App.Dtos;
using HotelBooking.App.IServices;
using HotelBooking.App.Mappings;

namespace HotelBooking.Api.Endpoints;

public static class Endpoints
{
    public static WebApplication RegisterEndpoints(this WebApplication app) {

        var v1 = app.MapGroup("/v1");

        /* __________________ CATEGORIES __________________ */

        var category = v1.MapGroup("/categories");

        // GET ALL
        category.MapGet("/", async (ICategoryService categoryService) => {
            var categories = await categoryService.GetAllAsync();
            return Results.Ok(categories);
        });

        // GET BY ID
        category.MapGet("/{id}", async (int id, ICategoryService categoryService) => {
            var category = await categoryService.GetByIdAsync(id);
            return category is null ? Results.NotFound() : Results.Ok(category);
        });

        // CREATE
        category.MapPost("/", async (CreateCategoryDto createCategoryDto, ICategoryService categoryService) => {
            var createdCategory = await categoryService.AddAsync(createCategoryDto);
            return Results.Created($"/v1/category/{createdCategory.Id}", createdCategory.ToCategoryResponseDto());
        });

        // UPDATE
        category.MapPut("/", (UpdateCategoryDto updateCategoryDto, ICategoryService categoryService) => {
            categoryService.UpdateCategoryAsync(updateCategoryDto);
        });

         /* __________________ HOTELS __________________ */
        
        return app;
    }
}
