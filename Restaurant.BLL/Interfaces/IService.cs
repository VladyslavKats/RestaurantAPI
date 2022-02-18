using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        void Delete(int id);

        void Update(TEntity entity);

        void Create(TEntity entity);

        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        void Save();
    }
}
