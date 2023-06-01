using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesLayer.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        //CRUD işlemleri
        IQueryable<T> GetAll(bool trackChanges);
        IQueryable<T> GetById(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
