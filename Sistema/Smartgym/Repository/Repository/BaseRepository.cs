using Domain.Repository;
using Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly SmartgymContext SmartgymContext;

        public BaseRepository(SmartgymContext smartgymContext)
        {
            SmartgymContext = smartgymContext;
        }

        public void Incluid(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Add(entity);
            SmartgymContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Update(entity);
            SmartgymContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            SmartgymContext.Remove(entity);
            SmartgymContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return SmartgymContext.Set<TEntity>().ToList();
        }

        public TEntity GetbyId(long Id)
        {
            return SmartgymContext.Set<TEntity>().Find(Id);
        }

        public void Dispose()
        {
            SmartgymContext.Dispose();
        }
    }
}