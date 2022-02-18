using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class 
    {
        TEntity GetById(int id);

        IEnumerable<TEntity>  GetAll();

        void Add(TEntity entity);
        void Update(TEntity entity);

        void Delete(int id);

        void Save();

    }
}
