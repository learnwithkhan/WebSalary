using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSalary.Models;
using WebSalary.ViewModels;

namespace WebSalary.Controllers
{
   
    public class EmployeeController : Controller
    {
        myPayrollEntities mP = new myPayrollEntities();

        EmpFinalSalary myEmpFinal = new EmpFinalSalary();

        BusinessLogic.BLogic BL = new BusinessLogic.BLogic();

        public ActionResult Index()
        {
            return View(mP.tblEmployees.ToList());
        }


        public ActionResult Modify()
        {
            return View(mP.tblEmployees.ToList());
        }


        // Routine to Add Employee Info 
        public ActionResult AddEmployee()
        {
            
            // var aList = Values.Select((x, i) => new { Value = (x < 5), Data = x }).ToList();
            //ViewBag.noOfDependants = new SelectList(aList, "Value", "Data");

            return View();
        }

        
        [HttpPost ]
        public ActionResult AddEmployee( tblEmployee myEmp)
        {
          if (ModelState.IsValid)
            {
                mP.tblEmployees.Add(myEmp);
                mP.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

   
        //============ Delete Routine ===========

        public ActionResult Delete (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = mP.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmployee tblEmployee = mP.tblEmployees.Find(id);
            mP.tblEmployees.Remove(tblEmployee);
            mP.SaveChanges();
            return RedirectToAction("Index");
        }

        // ========================================

        //============ Edit Routine ====================

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = mP.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                mP.Entry(tblEmployee).State = EntityState.Modified;
                mP.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmployee);
        }

        //========================= Calculate Salary ================================

        public ActionResult CalcPay()
        {
            return View(mP.tblEmployees.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = mP.tblEmployees.Find(id);

            if (tblEmployee == null)
            {
                return HttpNotFound();
            }

            String myDD = BL.FinalSalary(Convert.ToInt16(tblEmployee.noOfDependants), tblEmployee.emp_gender.ToString(), Convert.ToDouble(tblEmployee.ITex), Convert.ToDouble(tblEmployee.EI), Convert.ToDouble(tblEmployee.CPP), Convert.ToDouble(tblEmployee.Additions), Convert.ToDouble(tblEmployee.FinalSalary));

            TempData["emp_id"] = tblEmployee.emp_id;
            TempData["emp_name"] = tblEmployee.emp_name;
            TempData["addition"] = tblEmployee.Additions;
            TempData["FinalValues"] = myDD;

            return RedirectToAction("FinalSalary");
        }

        public ActionResult FinalSalary()
        {
            myEmpFinal.emp_id = Convert.ToInt16(TempData["emp_id"]);
            myEmpFinal.emp_name = Convert.ToString(TempData["emp_name"]);
            myEmpFinal.additions = Convert.ToDouble(TempData["addition"]);
            myEmpFinal.Finalvalues = Convert.ToString(TempData["FinalValues"]);

            return View(myEmpFinal);
        }

        //========================= End Calculate Salary ============================
    }
}