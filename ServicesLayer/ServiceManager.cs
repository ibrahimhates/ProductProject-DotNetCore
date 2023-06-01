using RepositoriesLayer.Contracts;
using ServicesLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public class ServiceManager : IServicesManager
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IProductServices _productServices;

        public ServiceManager(ICategoryServices categoryServices, IProductServices productServices)
        {
            _categoryServices=categoryServices;
            _productServices=productServices;
        }

        public IProductServices ProductServices => _productServices;

        public ICategoryServices CategoryServices => _categoryServices;
    }
}
