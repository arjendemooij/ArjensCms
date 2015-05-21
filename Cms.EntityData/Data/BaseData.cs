using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arjen.Data;
using Cms.Data.IData;

namespace Cms.EntityData.Data
{
    public abstract class BaseData<TEntity>: IData<TEntity> where TEntity : class, IHasId
    {
        protected readonly IRepository<TEntity> Repository;

        protected BaseData(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public TEntity GetById(int id)
        {
            return Repository.Table.SingleOrDefault(x => x.Id == id);
        }

        public void Add(TEntity entity)
        {
            Repository.Table.Add(entity);
        }

        public void Update(TEntity entity)
        {
        }

        public void Delete(TEntity entity)
        {
            Repository.Table.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Repository.Table.ToList();
        }
    }
}
