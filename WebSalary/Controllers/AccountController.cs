using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSalary.Models;
using WebSalary.ViewModels;
using System.Web.Security;

namespace WebSalary.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account

        BusinessLogic.BLogic BL = new BusinessLogic.BLogic();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login logObject)
        {
            if (ModelState.IsValid)
            {

                bool isItValid = BL.isValidUser(logObject.UserEmail, logObject.UserPassword);

                if (isItValid)
                {
                    FormsAuthentication.SetAuthCookie(logObject.UserEmail, false);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Something Wrong");
                    return View("Error");
                   
                }


            }
            else
            {
                return View(logObject);
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Signup(tblLogin userlogin)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
           
        }

    }
}