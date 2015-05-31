using System.Collections.Generic;
using System.Web.Mvc;
using Arjen.Data.UnitOfWork;
using AttributeRouting.Web.Mvc;
using AutoMapper;
using Cms.Areas.Admin.Controllers.Mappers;
using Cms.Areas.Admin.Models;
using Cms.Data;
using Cms.IService;

namespace Cms.Areas.Admin.Controllers
{
    public class PageController : Controller
    {
        private IPageService _pageService;
        private PageMapper _pageMapper;
        private IUnitOfWork _unitOfWork;

        public PageController(IPageService pageService, PageMapper pageMapper, IUnitOfWork unitOfWork)
        {
            _pageService = pageService;
            _pageMapper = pageMapper;
            _unitOfWork = unitOfWork;
        }

        //
        // GET: /Admin/Page/

        public ActionResult Index()
        {            
            return View();
        }


        [HttpGet]
        [ActionName("Api")]
        public JsonResult List()
        {
            var pages = _pageService.GetAll();
            var pageModels = Mapper.Map<IEnumerable<Page>, IEnumerable<PageModel>>(pages);

            return Json(pageModels, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("Api")]
        public JsonResult Add(PageModel pageModel)
        {            
            var page = Mapper.Map<PageModel, Page>(pageModel);
            _pageService.AddPage(page);
            _unitOfWork.Save();

            return Json(true);
        }


        

        [HttpDelete]
        [ActionName("Api")]
        public JsonResult Delete(int id)
        {
            var page = _pageService.GetById(id);
            _pageService.Delete(page);
           _unitOfWork.Save();
            return Json(true);
        }

        //[Route("/Admin/Page")]
        //public JsonResult Add(PageModel page)
        //{
        //    return Json(page);
        //}

    }
}
