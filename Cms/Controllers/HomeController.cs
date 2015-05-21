using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cms.IService;
using Cms.Service;

namespace Cms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _testService;
        private readonly IPageService _pageService;

        public HomeController(ITestService testService, IPageService pageService)
        {
            _testService = testService;
            _pageService = pageService;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            _testService.TestAuditing();
            var pages = _pageService.GetAll().ToList();
            
            return View(pages);
        }

    }
}
