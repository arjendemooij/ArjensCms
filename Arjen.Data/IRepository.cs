using System.Data.Entity;
using System.Linq;

namespace Arjen.Data
{
    public interface IRepository<T>
        where T : class
    {
        IDbSet<T> Table { get; }
        IQueryable<T> GetBaseQuery();
        bool UseCache();
    }
}
