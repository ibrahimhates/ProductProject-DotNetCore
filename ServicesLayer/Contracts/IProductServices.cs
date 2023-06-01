using EntitiesLayer.Models;

namespace ServicesLayer.Contracts
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
        Task<Product> GetOneProductByIdAsync(int id, bool trackChanges);
        Task<Product> CreateOneProductAsync(Product product);
        Task UpdateOneProductAsync(int id, Product product, bool trackChanges);
        Task DeleteOneProductAsync(int id, bool trackChanges);
    }
}
