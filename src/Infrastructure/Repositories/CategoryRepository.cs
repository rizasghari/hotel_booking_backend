using HotelBooking.Domain.Entities;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Infrastructure.Data;
using HotelBooking.src.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly HotelBookingDbContext _dbContext;

    public CategoryRepository(HotelBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> AddAsync(Category category)
    {
        try
        {
            await _dbContext.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<(IEnumerable<Category>, int total)> GetAllAsync(int page, int size, bool desc, string search)
    {
        IQueryable<Category> allCategoriesQuery = _dbContext.Categories.Where(c => c.DeletedAt == null);
        IQueryable<Category> categoriesQuery = _dbContext.Categories.Where(c => c.DeletedAt == null);

        if (!string.IsNullOrEmpty(search))
        {
            categoriesQuery = categoriesQuery    
                .Where(c => EF.Functions.Like(c.Name, $"%{search}%"));
        }

        categoriesQuery = desc
            ? categoriesQuery.OrderByDescending(c => c.Id)
            : categoriesQuery.OrderBy(c => c.Id);

        var categories = await categoriesQuery
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        var total = await allCategoriesQuery.CountAsync();

        return (categories, total);
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _dbContext.Categories
            .FirstOrDefaultAsync(category => category.Id == id && category.DeletedAt == null);
    }

    public async Task UpdateAsync(Category category)
    {
        try
        {
            var existingCategory = await _dbContext.Categories.FindAsync(category.Id)
                ?? throw new NotFoundException("Category not found");

            _dbContext.Entry(existingCategory!)
                .CurrentValues
                .SetValues(category);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var existingCategory = await _dbContext.Categories.FindAsync(id)
                ?? throw new NotFoundException("Category not found");

            existingCategory.DeletedAt = DateTime.UtcNow;

            _dbContext.Entry(existingCategory!)
                .CurrentValues
                .SetValues(existingCategory);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
