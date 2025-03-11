using System;
using HotelBooking.App.Dtos;
using HotelBooking.Domain.Entities;

namespace HotelBooking.App.IServices;

public interface ICategoryService
{
    Task<CategoryDto?> GetByIdAsync(int id);
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<Category> AddAsync(CreateCategoryDto category);
    Task UpdateCategoryAsync(int id, UpdateCategoryDto category);
}
