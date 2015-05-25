using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cms.Areas.Admin.Controllers.Mappers;
using Cms.IService;

namespace Cms.Areas.Admin.Controllers
{
    public class PageController : Controller
    {
        private IPageService _pageService;
        private PageMapper _pageMapper;

        public PageController(IPageService pageService, PageMapper pageMapper)
        {
            _pageService = pageService;
            _pageMapper = pageMapper;
        }

        //
        // GET: /Admin/Page/

        public ActionResult List()
        {
            var pages = _pageService.GetAll();
            var viewModel = _pageMapper.MapToPageListModel(pages, null);

            return View(viewModel);
        }

    }
}
