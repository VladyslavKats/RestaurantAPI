
using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.EF;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL.Data
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly RestaurantDbContext context;
        private readonly DbSet<TEntity> collection;

        public GenericRepository(RestaurantDbContext context , DbSet<TEntity> collection )
        {
            this.context = context;
            this.collection = collection;
        }
        public void Delete(int id)
        {
            var item = collection.Find(id);
            if (item != null)
                collection.Remove(item);
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return collection;
        }

        public TEntity GetById(int id)
        {
            return collection.Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
