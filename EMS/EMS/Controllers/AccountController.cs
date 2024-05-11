using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EMS.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Admin model)
        {
            using (var context = new EmpDatabaseEntities())
            {
                bool isValid = context.Admins.Any(x => x.AdminId == model.AdminId && x.AdminPassword == model.AdminPassword);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.AdminId, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Invalid AdminId or Password");
                ViewBag.ErrorMessage = "Invalid AdminId or Password";
                return View();

            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
