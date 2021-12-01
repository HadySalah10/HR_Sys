using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class HR
    {

   
        public int? hrId { get; set; } 

        [Required(ErrorMessage ="Please Enter Vaild Name")]  
        [Range(5,20,ErrorMessage ="")]
        [StringLength(50)]
        public string fullName { get; set;}

        [StringLength(20)]

        public string hrUserName { get; set; }

        [Required(ErrorMessage = "Please Enter Vaild Password")]

        [StringLength(20)]
        public string password { get; set; }

        [NotMapped]
        [Compare("password", ErrorMessage = "Not Matched")]
        public string confirmPassword { get; set; }

        [RegularExpression(@"[a-z0-9]+@[a-z]+\.[a-z]{2,3}", ErrorMessage ="Invalid Email")]
        public string email { get; set; }



        //relation with employee table
        public virtual ICollection<Employee> Employees { get; set; }

        //relation with department table
        public virtual ICollection<Department> Departments { get; set; }

        //relation with Emp_Reports table
        public virtual ICollection<EmpReport> Emp_Reports { get; set; }

        //relation with General_Settings table
        public virtual ICollection<GeneralSettings> General_Settings { get; set; }
        //relation with nationality table
        public virtual ICollection<Nationality> Nationalities { get; set; }
        //relation with Types_Of_Vacations table
        public virtual ICollection<TypesOfVacationsEmp> TypesOfVacationsEmps { get; set; }
        //relation with Vacation_Types table
        public virtual ICollection<VacationType> Vacation_Types { get; set; }

        //relation with validation table

        [ForeignKey("Valids")]
        public int validationId { get; set; }
        public virtual Validations Valids { get; set; }
       
    }
}
