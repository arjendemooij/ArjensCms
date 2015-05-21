using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cms.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            //return RedirectToAction("Page", "Page", new{id=1});
            return RedirectToAction("Create", "Account");
        }
    }
}
