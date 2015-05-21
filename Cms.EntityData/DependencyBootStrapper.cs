using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arjen.Auditing;
using Arjen.Data;
using Arjen.Data.UnitOfWork;
using Arjen.IOC;
using Cms.Data.IData;
using Cms.EntityData.Data;

namespace Cms.EntityData
{
    public class DependencyBootStrapper
    {
        public void BootStrap()
        {
            IOCController.RegisterFactoryMethod<IUnitOfWorkFactory>(PerRequestUnitOfWorkFactory.GetInstance);
            IOCController.RegisterFactoryMethod(()=> IOCController.GetInstance<IUnitOfWorkFactory>().RequireUnitInstance());
            IOCController.RegisterFactoryMethod(()=>IOCController.GetInstance<IUnitOfWork>().GetObjectContext());
            IOCController.RegisterFactoryMethod<IAuditableContext>(() => IOCController.GetInstance<IUnitOfWork>().GetObjectContext() as IAuditableContext);


            IOCController.AutoRegisterInterface(GetType().Assembly);

            new Arjen.Auditing.DependencyBootStrapper().BootStrap();
            
        }

    }
}
