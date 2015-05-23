﻿using System.Web.Mvc;
using Cms.Controllers.Mappers;
using Cms.IService;
using Cms.Service;

namespace Cms.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpGet]
        public ActionResult Page(int id)
        {
            var page = _pageService.GetById(id);
            var viewModel = new PageModelMapper().MapToPageModel(page, null);

            return View(viewModel);
        }

    }
}
