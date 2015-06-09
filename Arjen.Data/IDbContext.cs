using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Arjen.Data
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry Entry(object o);
        void Dispose();
        RelatedObjectsConfiguration RelatedObjectsConfiguration { get; set; }
        CachingSettings CachingSettings { get; set; }
    }
}
