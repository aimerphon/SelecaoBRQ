using SelecaoBRQ.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace SelecaoBRQ.Data.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity entity);

        TEntity GetById(params object[] ids);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity entity);

        void Remove(int id);
    }
}
