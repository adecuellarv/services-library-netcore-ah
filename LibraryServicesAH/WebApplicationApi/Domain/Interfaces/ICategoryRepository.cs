using WebApplicationApi.Domain.Entities;

namespace WebApplicationApi.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category, int? id);
        Task DeleteCategory(int categoryId);
    }
}
