using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Arjen.Data.UnitOfWork;
using Cms.Controllers.Mappers;
using Cms.Data;
using Cms.IService;
using Cms.Models;
using Cms.Service;

namespace Cms.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IAccountService accountService, IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(CreateAccountModel model)
        {
            if (!TryValidateModel(model)) return View(model);


            Account account = new CreateAccountModelMapper().ToDataModel(null, model);

            _accountService.Persist(account);
            _unitOfWork.Save();

            return RedirectToAction("Index", "Home");
        }

        // login
        // register
        // logoff
        // edit
        // change password
        // partial login/logoff + edit + register
        // change password
    }
}