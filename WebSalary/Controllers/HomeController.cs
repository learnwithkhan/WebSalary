using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSalary.Models;

namespace WebSalary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult mysalary()
        {
            
            var context = new myPayrollEntities();

            //var mytotalSalaries = context.sp_TotalSalaries();

            var mytotalSalaries = context.sp_CalculateIndividualSalary(4);

            foreach (var mms in mytotalSalaries)
            {
                mms.ToString();
            }

              
                return View();
        }


        public ActionResult myShow()
        {
            return View();
        }
    }
}