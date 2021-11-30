using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models

{
    public class Employee : commonprops
    {


        public string emp_name { get; set; }
        public string emp_address { get; set; }
        public DateTime? emp_date_of_birth { get; set; }
        public string emp_gender { get; set; }
        public int? emp_ssn { get; set; }
        public DateTime? emp_hireDate { get; set; }

        //relation with department
        [ForeignKey("Department")]
        public int deptid { get; set; }
        public virtual Department Department { get; set; }

        //relation with general settings table
        public virtual List<General_settings> General_Settings { get; set; }

        //relation with nationality
        [ForeignKey("Nationality")]
        public int nationality_id { get; set; }
        public virtual Nationality Nationality { get; set; }

        //relation with emp_phones table
        public virtual List<Emp_Phones> Emp_Phones { get; set; }

        //relation with emptimes
        [ForeignKey("Emp_Times")]
        public int empTime_id { get; set; }
        public virtual Emp_Time Emp_Times { get; set; }

        //relation with emp_report table
        public virtual List<Emp_Report> Emp_Reports { get; set; }

        //relation with Types_Of_Vacations table
        public virtual List<Types_Of_Vacations_emp>  Types_Of_Vacations_Emps { get; set; }




        //public int? emp_salary { get; set; }





    }
}
