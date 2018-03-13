using OnlineShopping.Bll.Abstract;
using OnlineShopping.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShopping.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        InterfaceAdmistrator admistrator;
        public AccountController(InterfaceAdmistrator admistrator)
        {
            this.admistrator = admistrator;
        }
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (admistrator.Authenticate(model.Username,model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("","Invalid Username or Password!");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Admin");
        }
    }
}