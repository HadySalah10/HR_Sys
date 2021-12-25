using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models;
using HR_Sys.Models.BaseIDEntity;


namespace HR_Sys.ViewModels
{
    public class TypesOfVactionViewModel
    {
        public int? id { get; set; }

        [ForeignKey("emp")]
        public int empId { get; set; }

        [ForeignKey("VacationType")]
        public int vacId { get; set; }
        [Required (ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime? date { get; set; }
        [ForeignKey("days")]
        public int idDays { get; set; }

        //object from employee
        //public virtual Employee emp { get; set; }

        ////object from vacation
        //public virtual VacationType VacationType { get; set; }
        //// OBJECT FROM  days
        //public virtual Days days { get; set; }

    }
}
