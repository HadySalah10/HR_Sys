using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class HR
    {

   
        public int? hrId { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل الاسم ")]

        [Range(5,20,ErrorMessage ="لا يجب ان يقل عدد االاحرف عن خمسة احرف ولا يزيد عن عشرون حرف ")]
        [StringLength(50)]
        public string fullName { get; set;}

        [StringLength(20)]
        [Required(ErrorMessage = "من فضلك ادخل اسم مستخدم  ")]
        public string hrUserName { get; set; }

        [Required(ErrorMessage = "من فضبلك ادخل كلمة المرور")]

        [StringLength(20)]
        public string password { get; set; }

        [NotMapped]
        [Compare("password", ErrorMessage = "غير متطابق")]
        public string confirmPassword { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage ="بريد الكتروني غير صالح")]
        public string email { get; set; }



        //relation with employee table
        [InverseProperty("edit")]

        public virtual ICollection<Employee> EmployeesEdit { get; set; }

        [InverseProperty("Delete")]

        public virtual ICollection<Employee> EmployeesDelete { get; set; }

        [InverseProperty("Add")]
        public virtual ICollection<Employee> EmployeesAdd { get; set; }


        //relation with department table
        [InverseProperty("edit")]

        public virtual ICollection<Department> DepartmentsEdit { get; set; }

        [InverseProperty("Delete")]

        public virtual ICollection<Department> DepartmentsDelete { get; set; }

        [InverseProperty("Add")]
        public virtual ICollection<Department> DepartmentsAdd { get; set; }

        //relation with Emp_Reports table
        [InverseProperty("Add")]

        public virtual ICollection<EmpReport> Emp_ReportsAdd { get; set; }
        [InverseProperty("edit")]

        public virtual ICollection<EmpReport> Emp_ReportsEdit { get; set; }
        [InverseProperty("Delete")]

        public virtual ICollection<EmpReport> Emp_ReportsDelete { get; set; }

        //relation with General_Settings table
        [InverseProperty("Add")]

        public virtual ICollection<GeneralSettings> General_Settings { get; set; }
        [InverseProperty("edit")]

        public virtual ICollection<GeneralSettings> General_SettingsEdit { get; set; }
        [InverseProperty("Delete")]

        public virtual ICollection<GeneralSettings> General_SettingsDelete { get; set; }
        //relation with nationality table
        [InverseProperty("Add")]

        public virtual ICollection<Nationality> NationalitiesAdd { get; set; }
        [InverseProperty("edit")]

        public virtual ICollection<Nationality> NationalitiesEdit { get; set; }
        [InverseProperty("Delete")]

        public virtual ICollection<Nationality> NationalitiesDelete { get; set; }
        //relation with Types_Of_Vacations table
        [InverseProperty("Add")]

        public virtual ICollection<TypesOfVacationsEmp> TypesOfVacationsEmps { get; set; }
        [InverseProperty("edit")]

        public virtual ICollection<TypesOfVacationsEmp> TypesOfVacationsEmpsEdit { get; set; }
        [InverseProperty("Delete")]

        public virtual ICollection<TypesOfVacationsEmp> TypesOfVacationsEmpsDelete { get; set; }
        //relation with Vacation_Types table
        [InverseProperty("Add")]
        public virtual ICollection<VacationType> VacationTypes { get; set; }
        [InverseProperty("edit")]
        public virtual ICollection<VacationType> VacatioTypesEdit { get; set; }
        [InverseProperty("Delete")]
        public virtual ICollection<VacationType> VacatioTypesDelete { get; set; }

        //relation with Months table

        [InverseProperty("Add")]

        public virtual ICollection<Months> Months { get; set; }
        [InverseProperty("edit")]

        public virtual ICollection<Months> MonthsEdit { get; set; }

        [InverseProperty("Delete")]
        public virtual ICollection<Months> MonthsDelete { get; set; }

        //relation with validation table
        [Required(ErrorMessage = "من فضلك ادخل اسم المجموعة")]

        [ForeignKey("Valids")]
        public int validationId { get; set; }
        public virtual Validations Valids { get; set; }
       
    }
}
