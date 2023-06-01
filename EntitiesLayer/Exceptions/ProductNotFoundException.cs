using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) 
            : base($"Product Not Found with id:{id}")
        {
        }
    }
}
