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

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(category => category.Id == id);
    }

    public async Task UpdateCategoryAsync(Category category)
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
}
