using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Interfaces
{
    public interface IRepository<TEntity> 
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByIdWithDetailsAsync(int id);

        Task<IEnumerable<TEntity>>  GetAllAsync();

        Task<IEnumerable<TEntity>>  GetAllWithDetailsAsync();

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task SaveAsync();

    }
}
