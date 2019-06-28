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

        public void IncluidWithoutSave(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Add(entity);
        }

        public TEntity IncluidAndReturnEntity(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Add(entity);
            SmartgymContext.SaveChanges();

            return entity;
        }

        public TEntity IncluidWithoutSaveAndReturnEntity(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Add(entity);

            return entity;
        }

        public void Update(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Update(entity);
            SmartgymContext.SaveChanges();
        }

        public TEntity UpdateAndReturnEntity(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Update(entity);
            SmartgymContext.SaveChanges();

            return entity;
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

        public void SaveChanges()
        {
            SmartgymContext.SaveChanges();
        }

        public void Dispose()
        {
            SmartgymContext.Dispose();
        }
    }
}