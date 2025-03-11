using HotelBooking.Domain.Entities;

namespace HotelBooking.Domain.IRepositories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(int id);
    Task<(IEnumerable<Category>, int total)> GetAllAsync(int page = 1, int size = 10, bool desc = false, string search = "");
    Task<Category> AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}
