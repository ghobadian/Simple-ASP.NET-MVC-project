using DataLayer;
using DataLayer.Repositories;
using DataLayer.Services;
using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCms.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ILoginRepository loginRepository;
        private readonly MyCmsContext db = new MyCmsContext();

        public AccountsController()
        {
            loginRepository = new LoginRepository(db);
        }

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel, string ReturnUrl = "/")
        {
            if(ModelState.IsValid)
            {
                string userName = loginViewModel.UserName;
                bool userExists = loginRepository.DoesUserExists(userName, loginViewModel.Password);
                if(userExists)
                {
                    FormsAuthentication.SetAuthCookie(userName, loginViewModel.RememberMe);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError(userName, "user with this credentials not found");
                }
            }
            return RedirectToAction("Login", "Accounts", new { ReturnUrl});
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}