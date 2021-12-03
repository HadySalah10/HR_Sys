using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;
using HR_Sys.ValidationsAttributes;

namespace HR_Sys.Models

{
    public class Employee : CommonProps
    {

      

        [Required(ErrorMessage ="*")]
        [StringLength(50,MinimumLength =5)]
        public string empName { get; set; }


        [Required(ErrorMessage = "*")]
        [StringLength(150)]
        public string empAddress { get; set; }

        [Required(ErrorMessage = "*")]
        [Within20Years ]
        public DateTime empDateOfBirth { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(1)]
        public string empGender { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(14, 14, ErrorMessage = "يجب الا يقل الرقم القومى عن 14 رقم!")]
        [ServiceStack.DataAnnotations.Unique]
        public int empSsn { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = " من فضلك ادخل راتب صحيح")]
        public int? empNetSalary { get; set; }
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = " من فضلك ادخل راتب صحيح")]

        public float? empNonNetSalary { get; set; }
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = " من فضلك ادخل راتب صحيح")]

        public float? empGrossSalary { get; set; }


        [Required(ErrorMessage = "*")]
        [YearOfTheCompany]
        public DateTime empHireDate { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime? requiredAttendanceTime { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime? requiredDepartureTime { get; set; }
        public decimal? requiredSalaryPerHour { get; set; }
        public int? requiredDaysPerMonth { get; set; }

        [Required(ErrorMessage = "*")]
        public float requiredExtraHours { get; set; }
        [Required(ErrorMessage = "*")]
        public float requiredDeductHours { get; set; }

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

   

        //relation with emp_report table
        public virtual ICollection<EmpReport> EmpReports { get; set; }

        //relation with Types_Of_Vacations table
        public virtual ICollection<TypesOfVacationsEmp>  TypesOfVacationsEmps { get; set; }









    }
}
