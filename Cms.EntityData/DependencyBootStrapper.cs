using Arjen.Auditing;
using Arjen.Data.UnitOfWork;
using Arjen.IOC;

namespace Cms.EntityData
{
    public class DependencyBootStrapper
    {
        public void BootStrap()
        {   
            IOCController.Register<IUnitOfWork, CmsObjectContext>();
            IOCController.RegisterFactoryMethod(()=>IOCController.GetInstance<IUnitOfWork>().GetObjectContext());
            IOCController.RegisterFactoryMethod(() => IOCController.GetInstance<IUnitOfWork>().GetObjectContext() as IAuditableContext);

            IOCController.AutoRegisterInterface(GetType().Assembly);

            new Arjen.Auditing.DependencyBootStrapper().BootStrap();
            
        }

    }
}
