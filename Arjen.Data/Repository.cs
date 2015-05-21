using System.Data.Entity;

namespace Arjen.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IObjectContext _objectContext;

        public Repository(IObjectContext objectContext)
        {
            _objectContext = objectContext;            
        }


        public DbSet<T> Table {
            get { return _objectContext.Set<T>(); }
        }
    }
}
