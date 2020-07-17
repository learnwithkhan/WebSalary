using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSalary.ViewModels
{
    public class EmpFinalSalary
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public double additions { get; set; }
        public double total_deduction { get; set; }
        public double final_salary { get; set; }
        public string Finalvalues { get; set; }
    }
}