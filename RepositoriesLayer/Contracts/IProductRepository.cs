

using EntitiesLayer.Models;
using RepositoriesLayer.EFCore;

namespace RepositoriesLayer.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product> 
    {
        Task<IEnumerable<Product>> GetAllProductAsync(bool trackChanges);
        Task<Product?> GetProductByIdAsync(int id,bool trackChanges);
        void CreateOneProduct(Product product);
        void UpdateOneProduct(Product product); 
        void DeleteOneProduct(Product product);

    }
}
