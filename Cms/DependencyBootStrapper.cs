using System;
using System.Web.Mvc;
using System.Web.Routing;
using Arjen.IOC;

namespace Cms
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            return (IController) IOCController.GetInstance(controllerType);
        }
    }

    public class DependencyBootStrapper
    {
        public void BootStrap()
        {
            IOCController.Initialize(IOCImplementationType.StructureMap);
            new Arjen.Data.DependencyBootStrapper().BootStrap();
            new EntityData.DependencyBootStrapper().BootStrap();
            new Service.DependencyBootStrapper().BootStrap();
        }

    }
}