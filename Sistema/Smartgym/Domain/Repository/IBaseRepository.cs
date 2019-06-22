using System;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Incluid(TEntity entity);

        TEntity IncluidAndReturnId(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity GetbyId(long id);
    }
}