using System;
using HotelBooking.App.Dtos;
using HotelBooking.App.IServices;
using HotelBooking.App.Mappings;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.IRepositories;

namespace HotelBooking.App.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> AddAsync(CreateCategoryDto createCategoryDto)
    {
        return await _categoryRepository.AddAsync(createCategoryDto.ToEntity());
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories.Select(categoryEntity => categoryEntity.ToDto());
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        return category?.ToDto();
    }

    public async Task UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
    {
        await _categoryRepository.UpdateAsync(updateCategoryDto.ToEntity(id));
    }

    public async Task DeleteAsync(int id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}
