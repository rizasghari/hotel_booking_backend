using System;
using HotelBooking.App.Dtos;
using HotelBooking.Domain.Entities;

namespace HotelBooking.App.IServices;

public interface ICategoryService
{
    Task<CategoryDto?> GetByIdAsync(int id);
    Task<(IEnumerable<CategoryDto> list, int total)> GetAllAsync(int page, int size, bool desc, string search);
    Task<Category> AddAsync(CreateCategoryDto category);
    Task UpdateCategoryAsync(int id, UpdateCategoryDto category);
    Task DeleteAsync(int id);
}
