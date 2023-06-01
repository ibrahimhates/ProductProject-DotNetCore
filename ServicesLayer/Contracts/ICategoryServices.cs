using EntitiesLayer.Models;

namespace ServicesLayer.Contracts
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task<Category> CreateOneCategoryAsync(Category category);
        Task UpdateOneCategoryAsync(int id, Category category, bool trackChanges);
        Task DeleteOneCategoryAsync(int id, bool trackChanges);
    }
}
