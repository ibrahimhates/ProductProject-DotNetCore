using RepositoriesLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesLayer.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(RepositoryContext repositoryContext, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _repositoryContext=repositoryContext;
            _productRepository=productRepository;
            _categoryRepository=categoryRepository;
        }

        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
