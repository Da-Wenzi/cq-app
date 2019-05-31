using CQ.Note.Core.Models;
using CQ.Note.Core.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CQ.Note.Core.Repositories.Impl
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        private readonly DbContext _context;
        private readonly IDateTimeProvider _dateTimeProvider;

        public Repository(IUnitOfWork uow, IDateTimeProvider dateTimeProvider)
        {
            _context = uow.DbContext;
            _dateTimeProvider = dateTimeProvider;
        }


        public IQueryable<TEntity> Entities => _context.Set<TEntity>().AsQueryable();


        public IQueryable<TEntity> NoTrackingEntities => _context.Set<TEntity>().AsNoTracking();


        public TEntity Insert(TEntity entity)
        {
            if (typeof(TEntity).IsAssignableFrom(typeof(ICreateDateTime)))
            {
                (entity as ICreateDateTime).CreateDateTime = _dateTimeProvider.Now;
            }

            return _context.Add(entity).Entity;
        }

        public TEntity Remove(TEntity entity)
        {
            return _context.Remove(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (typeof(TEntity).IsAssignableFrom(typeof(IUpdateDateTime)))
            {
                (entity as IUpdateDateTime).UpdateDateTime = _dateTimeProvider.Now;
            }

            return _context.Update(entity).Entity;
        }



    }
}
