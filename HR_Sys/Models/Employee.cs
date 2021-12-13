using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;
using HR_Sys.ValidationsAttributes;
using Microsoft.AspNetCore.Mvc;

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

        [Within20Years ]
        public DateTime empDateOfBirth { get; set; }

        [Required(ErrorMessage = "*")]
    
        // 1 for male 0 for female
        public bool empGender { get; set; }

        [Required(ErrorMessage = "*")]
        [Remote("checkSsn", "Employee", ErrorMessage = "هذا الرقم موجود مسبقا")]

        [Range(14, 14, ErrorMessage = "يجب الا يقل الرقم القومى عن 14 رقم!")]
        [ServiceStack.DataAnnotations.Unique]
        public string empSsn { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = " من فضلك ادخل راتب صحيح")]
        public double? empNetSalary { get; set; }
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = " من فضلك ادخل راتب صحيح")]

        public double? empNonNetSalary { get; set; }
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = " من فضلك ادخل راتب صحيح")]

        public double? empGrossSalary { get; set; }


        [Required(ErrorMessage = "*")]
        [YearOfTheCompany]
        public DateTime empHireDate { get; set; }
        //   time supposed to be in work  
        [DataType(DataType.Time)]

        [Required(ErrorMessage = "*")]
        public DateTime requiredAttendanceTime { get; set; }
        //   time supposed to be end of his/her base  time  
        [DataType(DataType.Time)]


        [Required(ErrorMessage = "*")]
        public DateTime requiredDepartureTime { get; set; }

        public decimal? requiredSalaryPerHour { get; set; }
        public int? requiredDaysPerMonth { get; set; }

        [Required(ErrorMessage = "*")]
        public float requiredExtraHours { get; set; }
        [Required(ErrorMessage = "*")]
        public float requiredDeductHours { get; set; }


        public string phoneNum { get; set; }

        public string? phoneNum2 { get; set; }

        //relation with department
        [ForeignKey("Department")]
        public int deptid { get; set; }
        public virtual Department Department { get; set; }

        //relation with general settings table
        public virtual ICollection<EmployeeAttendance> GeneralSettings { get; set; }

        //relation with nationality
        [ForeignKey("Nationality")]
        public int nationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }


     

        //relation with emp_report table
        public virtual ICollection<EmpReport> EmpReports { get; set; }

        //relation with Types_Of_Vacations table
        public virtual ICollection<TypesOfVacationsEmp>  TypesOfVacationsEmps { get; set; }









    }
}
