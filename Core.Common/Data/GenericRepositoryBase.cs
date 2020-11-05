using Core.Common.Contracts;
using Core.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Data
{
    public abstract class GenericRepositoryBase<T, U> : IGenericRepository<T>
        where T : class, IIdentifiableEntity, new()
        where U : DbContext, new()

    {
        protected abstract T AddEntity(U entityContext, T entity);
        protected abstract T UpdateEntity(U entityContext, T entity);        
        protected abstract T GetEntity(U entityContext, int id);
        protected abstract IQueryable<T> GetEntities(U entityContext);

        public async Task<T> Create(T entity)
        {
            using (U entityContext = new U())
            {
                T addedEntity = AddEntity(entityContext, entity);
                await entityContext.SaveChangesAsync();
                return addedEntity;
            }          
        }

        public Task Delete(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChangesAsync();
            }

            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }

            return Task.CompletedTask;
        }

        public async Task<T> FilterBY(Expression<Func<T, bool>> predicate)
        {
            using (U entityContext = new U())
            {
                return await entityContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
            }
            
        }

        public IQueryable<T> Get()
        {
            using (U entityContext = new U())
            {
                return GetEntities(entityContext);
            }
        }

        public Task<T> Get(int id)
        {
            using (U entityContext = new U())
                return Task.FromResult(GetEntity(entityContext, id));
        }

        public void SaveChanges()
        {
           using (U entityContext = new U())
            {
                entityContext.SaveChanges();
            }
        }

        public Task<T> Update(T entity)
        {
            using (U entityContext = new U())
            {
                T existingEntity = UpdateEntity(entityContext, entity);

                SimpleMapper.PropertyMap(entity, existingEntity);

                entityContext.SaveChanges();
                return Task.FromResult(existingEntity);
            }
        }
    }
}
