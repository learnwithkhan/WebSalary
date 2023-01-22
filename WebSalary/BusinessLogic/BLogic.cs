using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSalary.Models;
using WebSalary.ViewModels;

namespace WebSalary.BusinessLogic
{
    public class BLogic
    {
        public bool isValidUser(string useremail,string userpassword)
        {
            tblEmployee emp = new tblEmployee();

            using (myPayrollEntities md = new myPayrollEntities())
            {
                emp = md.tblEmployees.Where(q => q.emp_email.Contains(useremail) && q.emp_password.Contains(userpassword)).SingleOrDefault();
            }

            if (emp == null)
            {
                return false; //dfasfdsafdsfasfdsafd
            }
            else
            {
                return true;
            }
        }


        public string FinalSalary(int dependant, string gender, double itex, double ei, double cpp, double additions, double grosssalary)
        {
            double Deductions = 0;
            double finalgross = 0;
            string FinalValues = "";

            if (gender == "Male")
            {
                switch (dependant)
                {
                    case (2):
                        Deductions = ((grosssalary * itex) + (grosssalary * ei) + (grosssalary * cpp))/12;

                        Deductions = Math.Round(Deductions, 2);

                        finalgross = ((grosssalary - Deductions) + additions)/12;

                        finalgross = Math.Round(finalgross, 2);

                      
                        FinalValues = "Final Salary  " + Convert.ToString(finalgross) + "  Total Deductions " + Convert.ToString(Deductions);
                        break;
                    case (3):
                        Deductions = ((grosssalary * (itex - 0.01)) + (grosssalary * ei) + (grosssalary * cpp))/12;
                        Deductions = Math.Round(Deductions, 2);

                      
                        finalgross = ((grosssalary - Deductions) + additions)/12;
                        finalgross = Math.Round(finalgross, 2);


                        FinalValues = "Final Salary  " + Convert.ToString(finalgross) + "  Total Deductions " + Convert.ToString(Deductions);
                        break;
                    case (4):
                        Deductions = ((grosssalary * (itex - 0.02)) + (grosssalary * ei) + (grosssalary * cpp))/12;

                        Deductions = Math.Round(Deductions, 2);

                        finalgross = ((grosssalary - Deductions) + additions)/12;

                        finalgross = Math.Round(finalgross, 2);

                        FinalValues = "Final Salary  " + Convert.ToString(finalgross) + "  Total Deductions " + Convert.ToString(Deductions);
                        break;
                }

            }
            else if (gender == "Female")
            {
                switch (dependant)
                {
                    case (2):
                        Deductions = ((grosssalary * itex) + (grosssalary * ei) + (grosssalary * cpp))/12;

                        Deductions = Math.Round(Deductions, 2);


                        finalgross = ((grosssalary - Deductions) + additions)/12;

                        finalgross = Math.Round(finalgross, 2);

                        FinalValues = "Final Salary  " + Convert.ToString(finalgross) + " Total Deductions " + Convert.ToString(Deductions);
                        break;
                    case (3):
                        Deductions = ((grosssalary * (itex - 0.01)) + (grosssalary * ei) + (grosssalary * cpp))/12;
                        Deductions = Math.Round(Deductions, 2);

                        finalgross = ((grosssalary - Deductions) + additions)/12;

                        finalgross = Math.Round(finalgross, 2);

                        FinalValues = "Final Salary  " + Convert.ToString(finalgross) + " Total Deductions " + Convert.ToString(Deductions);
                        break;
                    case (4):
                        Deductions = ((grosssalary * (itex - 0.02)) + (grosssalary * ei) + (grosssalary * cpp))/12;
                        Deductions = Math.Round(Deductions, 2);

                        finalgross = ((grosssalary - Deductions) + additions)/12;

                        finalgross = Math.Round(finalgross, 2);

                        FinalValues = "Final Salary  " + Convert.ToString(finalgross) + " Total Deductions " + Convert.ToString(Deductions);
                        break;
                }


            }
            return FinalValues;
        }

    }
}