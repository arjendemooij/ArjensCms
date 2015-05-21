using System.Data.Entity;

namespace Arjen.Data
{
    public interface IRepository<T>
        where T : class
    {
        DbSet<T> Table { get; }
    }
}
