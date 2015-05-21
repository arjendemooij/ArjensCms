using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Arjen.Auditing
{
    public interface IEntityChangeAuditor
    {
        void Audit(DbEntityEntry entityEntry);

    }
}