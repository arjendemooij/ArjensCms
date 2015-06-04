using System.Collections.Generic;
using System.Web.Mvc;
using Arjen.Data.UnitOfWork;
using Arjen.Helpers;
using AutoMapper;
using Cms.Areas.Admin.Models;
using Cms.Data;
using Cms.IService;

namespace Cms.Areas.Admin.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;

        public PageController(IPageService pageService, IUnitOfWork unitOfWork, IAccountService accountService)
        {
            _pageService = pageService;
            _unitOfWork = unitOfWork;
            _accountService = accountService;
        }

        
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [ActionName("Api")]
        public JsonResult List(int? id, int? pageNumber, int? pageSize)
        {
            if (id == null)
            {
                PagedList<Page> pages = _pageService.GetAll(pageNumber.Value, pageSize.Value);
                var pageModels = new PagedList<PageModel>()
                    {
                        Data = Mapper.Map<IEnumerable<Page>, IEnumerable<PageModel>>(pages.Data),
                        PageCount = pages.PageCount,
                        PageNumber = pages.PageNumber,
                        PageSize = pages.PageSize
                    };

                return Json(pageModels, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var page = _pageService.GetById(id.Value);
                var authorOptions = _accountService.GetAll();
                var pageModel = Mapper.Map<Page, PageModel>(page);
                pageModel.AuthorOptions = Mapper.Map<IEnumerable<Account>, IEnumerable<PageAuthorModel>>(authorOptions);

                return Json(pageModel, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ActionName("Api")]
        public JsonResult Save(PageModel pageModel)
        {
            if (pageModel.Id == 0)
            {
                var page = Mapper.Map<PageModel, Page>(pageModel);
                _pageService.AddPage(page);
                _unitOfWork.Save();
            }
            else
            {
                var page = _pageService.GetById(pageModel.Id);
                Mapper.Map(pageModel, page);
                page.Author = _accountService.GetById(pageModel.Author.Id);

                _pageService.SavePage(page);
                _unitOfWork.Save();

            }
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

    }
}
