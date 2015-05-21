using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cms.IService;
using Cms.Service;
using log4net;

namespace Cms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _testService;
        private readonly IPageService _pageService;
        private ILog _logger;

        public HomeController(ITestService testService, IPageService pageService, ILog logger)
        {
            _testService = testService;
            _pageService = pageService;
            _logger = logger;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {

            _logger.Info("Test");

            _testService.TestAuditing();
            var pages = _pageService.GetAll().ToList();
            
            return View(pages);
        }

    }
}
