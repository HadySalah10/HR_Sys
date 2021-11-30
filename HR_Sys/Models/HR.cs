using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models
{
    public class HR
    {

        public int? hr_id { get; set; } 
        public string fullname { get; set;}
        public string hr_username { get; set; }
        public string password { get; set; }
        public string email { get; set; }




        //relation with employee table
        public virtual List<Employee> Employees { get; set; }
        //relation with department table
        public virtual List<Department> Departments { get; set; }

        //relation with Emp_Reports table
        public virtual List<Emp_Report> Emp_Reports { get; set; }

        //relation with General_Settings table
        public virtual List<General_settings> General_Settings { get; set; }
        //relation with nationality table
        public virtual List<Nationality> Nationalities { get; set; }
        //relation with Types_Of_Vacations table
        public virtual List<Types_Of_Vacations_emp> Types_Of_Vacations { get; set; }
        //relation with Vacation_Types table
        public virtual List<Vacation_Type> Vacation_Types { get; set; }

        //relation with validation table

        [ForeignKey("Valids")]
        public int validation_id { get; set; }
        public virtual Validations Valids { get; set; }

    }
}
