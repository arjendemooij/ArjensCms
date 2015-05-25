using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Cms.IService;
using Cms.Models;

namespace Cms.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!_accountService.AreValidCredentials(loginModel.UsernameOrEmail, loginModel.Password))
            {
                return View(); 
            }

            FormsAuthentication.SetAuthCookie(loginModel.UsernameOrEmail, true);
            return RedirectToAction("Index", "Home");
        }

    }
}
