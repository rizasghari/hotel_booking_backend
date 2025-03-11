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

    public async Task<(IEnumerable<CategoryDto> list, int total)> GetAllAsync(int page, int size, bool desc, string search)
    {
        (IEnumerable<Category> categories, int total) = await _categoryRepository.GetAllAsync(page, size, desc, search);

        var convertedCategories = categories.Select(categoryEntity => categoryEntity.ToDto()).ToList();
        return (convertedCategories, total);
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
