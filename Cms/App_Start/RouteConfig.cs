using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Arjen.IOC;
using Cms.IService;
using Cms.Service;

namespace Cms.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var pageService = IOCController.GetInstance<IPageService>();
            if (pageService.ArePageUrlsUnique())
            {
                var pages = pageService.GetAll().ToList();
                foreach (var page in pages)
                {
                    routes.MapRoute(
                    name: page.SeoUrl
                    , url: page.SeoUrl
                    , defaults: new { controller = "Page", action = "Page", id = page.Id }
                    );
                }
            }


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}