using Arjen.Auditing;
using Arjen.Data;
using Arjen.IOC;

namespace Cms.EntityData
{
    public class DependencyBootStrapper
    {
        public void BootStrap()
        {   
            IOCController.Register<IUnitOfWork, UnitOfWork>();
            IOCController.Register<IDbContext, CmsObjectContext>();
            IOCController.Register<IEntityChangeAuditor, EntityChangeAuditor>();
            IOCController.RegisterFactoryMethod(() => IOCController.GetInstance<IDbContext>() as IAuditableContext);

            IOCController.AutoRegisterInterface(GetType().Assembly);

            new Arjen.Auditing.DependencyBootStrapper().BootStrap();
            
        }

    }
}
