using System.Web.Mvc;
using System.Web.Security;
using Cms.IService;
using Cms.Areas.Admin.Models;

namespace Cms.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

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
            return RedirectToAction("List", "Account");
        }

    }
}
