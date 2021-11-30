using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models
{
    public class Emp_Report :commonprops
    {
        public string month { get; set; } 
        public int? year { get; set; }    
        public int? no_attendance_days { get; set; }
        public int? no_absence_days { get; set; }
        public float? no_of_extrahours { get; set; }
        public float? no_of_deducthours { get; set; }
        public float? total_of_extra_price { get; set; }
        public float? total_of_deduction_price { get; set; }

        //public float? gross_salary { get; set; }
        public float? net_salary { get; set; }


        //relation with employee
        [ForeignKey("Employees")]
        public int emp_id { get; set; }
        public virtual Employee Employees { get; set; }



    }
}
