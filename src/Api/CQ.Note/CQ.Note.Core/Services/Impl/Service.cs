using AutoMapper;
using CQ.Note.Core.Models;
using CQ.Note.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQ.Note.Core.Services.Impl
{
    public class Service<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : EntityBase<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IRepository<TEntity, TKey> Repository;
        protected readonly IMapper Mapper;

        public Service(IUnitOfWork uow, IRepository<TEntity, TKey> repository, IMapper mapper)
        {
            UnitOfWork = uow;
            Repository = repository;
            Mapper = mapper;
        }


        public virtual IEnumerable<TEntity> GetAll()
        {
            return Repository.NoTrackingEntities.ToList();
        }


        public virtual TEntity Find(TKey id)
        {
            return UnitOfWork.DbContext.Find<TEntity>(id);
        }


        public virtual async Task<TEntity> FindAsync(TKey id)
        {
            return await UnitOfWork.DbContext.FindAsync<TEntity>(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Repository.Insert(entity);
            UnitOfWork.Commit();
        }

        public virtual void Update(TEntity entity)
        {
            Repository.Update(entity);
            UnitOfWork.Commit();
        }

        public virtual void Delete(TKey id)
        {
            TEntity entity = Repository.Entities.FirstOrDefault(e => e.Id.Equals(id));
            if (entity != null)
            {
                Repository.Remove(entity);
                UnitOfWork.Commit();
            }
        }
    }
}
