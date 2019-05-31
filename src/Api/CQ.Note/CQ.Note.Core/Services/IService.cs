using CQ.Note.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQ.Note.Core.Services
{
    public interface IService<TEntity, TKey>
        where TEntity : EntityBase<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Find(TKey id);

        Task<TEntity> FindAsync(TKey id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TKey id);
    }
}
