using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cms.IService;

namespace Cms.Areas.Admin.Controllers
{
    [Authorize()]
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult List()
        {
            var accounts = _accountService.GetAll();

            return View(accounts);
        }
    

    }
}
