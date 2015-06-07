using System.Collections.Generic;
using System.Linq;
using Arjen.Data;

namespace Cms.Data.IData
{
    public interface IData<TEntity>
        where TEntity : IHasId  
    {
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetBaseQuery();
    }
}
