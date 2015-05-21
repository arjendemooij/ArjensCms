using System.Collections.Generic;

namespace Cms.Data.IData
{
    public interface IHasId
    {
        int Id { get; }
    }


    public interface IData<TEntity>
        where TEntity : IHasId  
    {
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();

    }
}
