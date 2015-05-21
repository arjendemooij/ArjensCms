using System.Data.Entity;

namespace Arjen.Data
{
    public interface IObjectContext
    {
        DbSet<T> Set<T>() where T : class;

    }
}
