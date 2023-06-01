using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesLayer.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync(bool trackChanges);
        Task<Category?> GetCategoryByIdAsync(int id, bool trackChanges);
        void CreateOneCategory(Category category);
        void UpdateOneCategory(Category category);
        void DeleteOneCategory(Category category);
    }
}
