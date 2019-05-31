using CQ.Note.Core.Models;
using System;
using System.Linq;

namespace CQ.Note.Core.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        IQueryable<TEntity> Entities { get; }


        IQueryable<TEntity> NoTrackingEntities { get; }


        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Remove(TEntity entity);

    }
}
