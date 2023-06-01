using EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoriesLayer.Contracts;

namespace RepositoriesLayer.EFCore
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync(bool trackChanges)
        {
            var entities = await GetAll(trackChanges)
                .Include(p => p.Category)
                .OrderBy(x => x.Id)
                .ToListAsync();
            return entities;
        }
        public async Task<Product?> GetProductByIdAsync(int id, bool trackChanges)
        {
            var entity = await GetById(x => x.Id == id,trackChanges)
                .Include(p => p.Category)
                .SingleOrDefaultAsync();
            return entity;
        }
        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Delete(product);

        public void UpdateOneProduct(Product product) => Update(product);
    }
}
