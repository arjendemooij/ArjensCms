using System.Web;

namespace Arjen.Data.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork RequireUnitInstance();
        void DestroyUnitInstance();
    }

    
}
