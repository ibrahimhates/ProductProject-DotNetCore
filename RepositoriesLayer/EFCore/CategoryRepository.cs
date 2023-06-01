using EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoriesLayer.Contracts;

namespace RepositoriesLayer.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync(bool trackChanges)
        {
            var entity = await GetAll(trackChanges)
                .OrderBy(x => x.Id)
                .ToListAsync();
            return entity;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id, bool trackChanges)
        {
            var entity = await GetById(x => x.Id == id, trackChanges)
                .SingleOrDefaultAsync();
            return entity;
        }

        public void CreateOneCategory(Category category) => Create(category);

        public void DeleteOneCategory(Category category) => Delete(category);
        
        public void UpdateOneCategory(Category category) => Update(category);
    }
}
