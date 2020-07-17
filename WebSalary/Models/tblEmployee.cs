//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace WebSalary.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEmployee
    {
        public int emp_id { get; set; }
        [Required(ErrorMessage ="Please Provide Name")]
        
        public string emp_name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string emp_email { get; set; }

        [Required(ErrorMessage = "Please Provide Password")]
        [DataType(DataType.Password)]
        public string emp_password { get; set; }
        public string emp_gender { get; set; }
        public Nullable<int> noOfDependants { get; set; }
        public Nullable<decimal> Additions { get; set; }
        public Nullable<decimal> ITex { get; set; }
        public Nullable<decimal> CPP { get; set; }
        public Nullable<decimal> EI { get; set; }
        public Nullable<decimal> FinalSalary { get; set; }
    }
}
