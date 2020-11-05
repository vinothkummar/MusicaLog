using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{
    public interface IGenericRepository
    {

    }

    public interface IGenericRepository<T> : IGenericRepository where T : class, IIdentifiableEntity, new()
    {
        IQueryable<T> Get();

        Task<T> FilterBY(Expression<Func<T, bool>> predicate);

        Task<T> Create(T entity);

        Task Delete(T entity);

        Task Delete(int id);

        Task<T> Update(T entity);

        Task<T> Get(int id);

        void SaveChanges();
       
    }
}
