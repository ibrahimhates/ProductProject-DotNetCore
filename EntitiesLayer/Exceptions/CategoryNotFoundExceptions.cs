using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Exceptions
{
    public class CategoryNotFoundExceptions : NotFoundException
    {
        public CategoryNotFoundExceptions(int id) 
            : base($"Category Not Found with id:{id}")
        {
        }
    }
}
