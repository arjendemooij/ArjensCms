using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Arjen.Data.UnitOfWork;
using Arjen.IOC;
using Cms.App_Start;

namespace Cms
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            new DependencyBootStrapper().BootStrap();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            IOCController.GetInstance<IUnitOfWorkFactory>().RequireUnitInstance();
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            IOCController.GetInstance<IUnitOfWorkFactory>().DestroyUnitInstance();
        }
    }


}