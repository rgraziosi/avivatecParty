using AvivatecParty.Domain.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AvivatecParty.Domain.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        int SaveChanges();

        // commands
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(Guid id);

        // querys
        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}