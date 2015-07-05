using FormManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormManager.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(LoginViewModel vm, string returnUrl)
        {
            //if (!ValidateLogOn(vmuserName, password))
            //    return View("LogOn");
            //if(ValidateModel(vm))
            if (ModelState.IsValid && FormsAuthentication.Authenticate(vm.Username, vm.Password))
            {
                FormsAuthentication.SetAuthCookie(vm.Username, false);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else

                    return RedirectToAction("Menu", "Form");
            }
            else
            {
                ModelState.AddModelError("", "Wrong username and password");
               
            } 
            return View(vm);
        }

        private bool ValidateLogOn(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                ModelState.AddModelError("username", "User name required");

            if (string.IsNullOrEmpty(password))
                ModelState.AddModelError("password", "Password required");

            if (ModelState.IsValid && !FormsAuthentication.
                Authenticate(userName, password))
                ModelState.AddModelError("_FORM", "Wrong user name or password");

            return ModelState.IsValid;
        }

        public RedirectToRouteResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("LogOn");
        }
    }
}