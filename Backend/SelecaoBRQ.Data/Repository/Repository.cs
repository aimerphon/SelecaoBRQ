using SelecaoBRQ.Data.Interfaces;
using SelecaoBRQ.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace SelecaoBRQ.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {

        protected Repository()
        {
        }

        public abstract void Add(TEntity entity);

        public abstract TEntity GetById(params object[] ids);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract void Update(TEntity entity);

        public abstract void Remove(int id);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
