using System;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Incluid(TEntity entity);

        void IncluidWithoutSave(TEntity entity);

        TEntity IncluidAndReturnEntity(TEntity entity);

        TEntity IncluidWithoutSaveAndReturnEntity(TEntity entity);

        void Update(TEntity entity);

        TEntity UpdateAndReturnEntity(TEntity entity);

        void Remove(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity GetbyId(long id);

        void SaveChanges();
    }
}