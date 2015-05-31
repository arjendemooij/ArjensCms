using System;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Arjen.Data.UnitOfWork;
using Arjen.IOC;
using Cms.App_Start;
using Cms.Areas.Admin.Controllers.Mappers;
using Cms.EntityData;
using Cms.EntityData.Migrations;
using log4net;
using log4net.Config;

namespace Cms
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            XmlConfigurator.Configure();
            
            new DependencyBootStrapper().BootStrap();
            new AutoMapperConfigurator().Configure();
            
            CmsObjectContext.UpdateDatabase();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            LogManager.GetLogger("RequestLogger").Debug("START " + Context.Request.RawUrl);
            IOCController.GetInstance<IUnitOfWorkFactory>().RequireUnitInstance();
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            IOCController.GetInstance<IUnitOfWorkFactory>().DestroyUnitInstance();

            LogManager.GetLogger("RequestLogger").Debug("END " + this.Context.Request.RawUrl);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            ILog log;
            Exception lastException = Server.GetLastError();

            try
            {
                log = IOCController.GetInstance<ILog>();
            }
            catch
            {
                log = LogManager.GetLogger("root");
            }

            log.Fatal("Top level application exception", lastException);
            LogManager.GetLogger("RequestLogger").Error("ERROR " + this.Context.Request.RawUrl);
        }
    }


}