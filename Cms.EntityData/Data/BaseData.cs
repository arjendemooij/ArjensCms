using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arjen.Cache;
using Arjen.Data;
using Cms.Data;
using Cms.Data.IData;

namespace Cms.EntityData.Data
{
    public abstract class BaseData<TEntity>: IData<TEntity> where TEntity : class, IHasId
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly IEntityCache EntityCache;

        protected BaseData(IEntityCache entityCache)
        {
            EntityCache = entityCache;
        }

        protected BaseData(IRepository<TEntity> repository, IEntityCache entityCache)
        {
            Repository = repository;
            EntityCache = entityCache;
        }

        public virtual TEntity GetById(int id)
        {
            using (new QueryContext().NoCache())
            {
                return GetBaseQuery().SingleOrDefault(x => x.Id == id);
            }
        }

        public virtual void Add(TEntity entity)
        {
            Repository.Table.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
                
        }

        public virtual void Delete(TEntity entity)
        {
            Repository.Table.Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetBaseQuery().ToList();
        }

        public virtual IQueryable<TEntity> TableWithIncludes()
        {
            return AddDefaultIncludes(Repository.GetBaseQuery());
        }

        public IQueryable<TEntity> GetBaseQuery()
        {
            if(Repository.UseCache())
            {
                return EntityCache.HasListCache<TEntity>()
                   ? EntityCache.GetCachedList<TEntity>().AsQueryable()
                   : EntityCache.CacheList(TableWithIncludes().ToList()).AsQueryable();
            }
            else
            {
                return TableWithIncludes();
            }
            
        }

        protected virtual IQueryable<TEntity> AddDefaultIncludes(IQueryable<TEntity> baseQuery )
        {
            return baseQuery;
        } 
    }
}
