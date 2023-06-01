using EntitiesLayer.Exceptions;
using EntitiesLayer.Models;
using RepositoriesLayer.Contracts;
using ServicesLayer.Contracts;

namespace ServicesLayer
{
    public class CategoryManager : ICategoryServices
    {
        private readonly IRepositoryManager _manager;
        public CategoryManager(IRepositoryManager manager)
        {
            _manager=manager;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _manager.Category.GetAllCategoryAsync(trackChanges);
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAndCheckExits(id, trackChanges);
            return entity;
        }

        public async Task<Category> CreateOneCategoryAsync(Category category)
        {
            _manager.Category.CreateOneCategory(category);
            await _manager.SaveAsync();
            return category;
        }

        public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAndCheckExits(id,trackChanges);
            var product = (await _manager
                .Product.
                GetAllProductAsync(trackChanges))
                .Where(x => x.CategoryId == id).
                FirstOrDefault();

            if (product is not null)
                throw new Exception("You cannot delete an affiliated product with this category.");
            
            _manager.Category.DeleteOneCategory(entity);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneCategoryAsync(int id, Category category, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAndCheckExits(id, trackChanges);

            // Todo AutoMapper Kullanılması gerekiyor Category.
            entity.CategoryName = category.CategoryName;

            _manager.Category.UpdateOneCategory(entity);
            await _manager.SaveAsync();
        }
        private async Task<Category> GetOneCategoryByIdAndCheckExits(int id, bool trackChanges)
        {
            var enitity = await _manager.Category.GetCategoryByIdAsync(id, trackChanges);
            if (enitity is null)
                throw new CategoryNotFoundExceptions(id);
            return enitity;
        }
    }
}
