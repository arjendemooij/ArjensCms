using System.Data.Entity;
using System.Linq;

namespace Arjen.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IObjectContext _objectContext;

        public Repository(IObjectContext objectContext)
        {
            _objectContext = objectContext;
        }

        public IQueryable<T> GetBaseQuery()
        {
            var set = _objectContext.Set<T>();
            var withIncludes = _objectContext.RelatedObjectsConfiguration.AddIncludesToQuery(set);

            return withIncludes;
        }

        public bool UseCache()
        {
            return _objectContext.CachingSettings.UseCache;
        }

        public IDbSet<T> Table
        {
            get
            {
                return _objectContext.Set<T>();
            }
        }
    }
}
