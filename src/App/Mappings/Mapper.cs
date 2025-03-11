using System;
using HotelBooking.App.Dtos;
using HotelBooking.Domain.Entities;

namespace HotelBooking.App.Mappings;

public static class Mapper
{
    public static CategoryDto ToCategoryDto(this CreateCategoryDto createCategoryDto) {
        return new CategoryDto {
            Name = createCategoryDto.Name,
        };
    }

    public static Category ToEntity(this CreateCategoryDto createCategoryDto) {
        return new Category {
            Name = createCategoryDto.Name
        };
    }

    public static CategoryDto ToDto(this Category category) {
        return new CategoryDto {
            Id = category.Id,
            Name = category.Name,
            Icon = category.Icon
        };
    }

    public static Category ToEntity(this CategoryDto categoryDto) {
        return new Category {
            Id = categoryDto.Id,
            Name = categoryDto.Name,
            Icon = categoryDto.Icon
        };
    }

    public static CategoryResponseDto ToCategoryResponseDto(this Category category) {
        return new CategoryResponseDto {
            Id = category.Id,
            Name = category.Name,
            Icon = category.Icon
        };
    }

    public static Category ToEntity(this UpdateCategoryDto updateCategoryDto, int id) {
        return new Category {
            Id = id,
            Name = updateCategoryDto.Name,
        };
    }
}
