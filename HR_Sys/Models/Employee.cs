using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;



namespace HR_Sys.Models

{
    public class Employee : CommonProps
    {

      

        [Required(ErrorMessage ="Required")]
        [StringLength(50,MinimumLength =5)]
        public string empName { get; set; }


        [Required(ErrorMessage = "Required")]
        [StringLength(150)]
        public string empAddress { get; set; }

        [Required(ErrorMessage = "Required")]
        public DateTime empDateOfBirth { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(1)]
        public string empGender { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(14, 14, ErrorMessage = "Please Enter a Vaild National ID")]
        [ServiceStack.DataAnnotations.Unique]
        public int empSsn { get; set; }

        [Required(ErrorMessage = "Required")]
        public int? empNetSalary { get; set; }
        public float? empNonNetSalary { get; set; }
        public float? empGrossSalary { get; set; }


        [Required(ErrorMessage = "Required")]

        public DateTime empHireDate { get; set; }

        //relation with department
        [ForeignKey("Department")]
        public int deptid { get; set; }
        public virtual Department Department { get; set; }

        //relation with general settings table
        public virtual ICollection<GeneralSettings> GeneralSettings { get; set; }

        //relation with nationality
        [ForeignKey("Nationality")]
        public int nationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }

        //relation with emp_phones table
        public virtual ICollection<EmpPhones> EmpPhones { get; set; }

        //relation with emptimes
        [ForeignKey("EmpTime")]
        public int empTimeId { get; set; }
        public virtual EmpTime EmpTime { get; set; }

        //relation with emp_report table
        public virtual ICollection<EmpReport> EmpReports { get; set; }

        //relation with Types_Of_Vacations table
        public virtual ICollection<TypesOfVacationsEmp>  TypesOfVacationsEmps { get; set; }









    }
}
