using EntitiesLayer.Exceptions;
using EntitiesLayer.Models;
using RepositoriesLayer.Contracts;
using ServicesLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public class ProductManager : IProductServices
    {
        private readonly IRepositoryManager _manager;
        private readonly ICategoryServices _categoryServices;

        public ProductManager(IRepositoryManager manager,
            ICategoryServices categoryServices)
        {
            _manager=manager;
            _categoryServices=categoryServices;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
        {
            return await _manager.Product.GetAllProductAsync(trackChanges);
        }

        public async Task<Product> GetOneProductByIdAsync(int id, bool trackChanges)
        {
            var entity = await GetOneProductByIdAndCheckExits(id, trackChanges);
            return entity;
        }

        public async Task<Product> CreateOneProductAsync(Product product)
        {
            await _categoryServices
                .GetOneCategoryByIdAsync(product.CategoryId, false);

            _manager.Product.CreateOneProduct(product);
            await _manager.SaveAsync();
            return product;
        }

        public async Task DeleteOneProductAsync(int id, bool trackChanges)
        {
            var entity = await GetOneProductByIdAndCheckExits(id, trackChanges);
            _manager.Product.DeleteOneProduct(entity);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneProductAsync(int id, Product product, bool trackChanges)
        {
            var entity = await GetOneProductByIdAndCheckExits(id, trackChanges);
            await _categoryServices.GetOneCategoryByIdAsync(product.CategoryId, false);

            //Todo AutoMapper Kullanılması gerekiyor.
            entity.CategoryId = product.CategoryId;
            entity.Price = product.Price;
            entity.Name = product.Name;

            _manager.Product.UpdateOneProduct(entity);
            await _manager.SaveAsync();
        }

        private async Task<Product> GetOneProductByIdAndCheckExits(int id,bool trackChanges)
        {
            var entity = await _manager.Product.GetProductByIdAsync(id,trackChanges);
            if (entity is null)
                throw new ProductNotFoundException(id);

            return entity;
        }
    }
}
