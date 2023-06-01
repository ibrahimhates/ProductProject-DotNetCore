using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesLayer.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        Task SaveAsync();
    }
}
