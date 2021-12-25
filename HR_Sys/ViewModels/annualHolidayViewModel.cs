using HR_Sys.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.ViewModels
{
    public class annualHolidayViewModel
    {
        //اسم الأجازه 
        [DisplayName("اسـم الأجازه")]
        //[Required(ErrorMessage = "برجاء تحديد اسـم الأجازه")]

        [ForeignKey("NameAnnualHoliday")]
        public virtual NameAnnualHoliday? NameAnnualHoliday { get; set; }

        //تاريخ الأجازه
        [Required(ErrorMessage = "برجاء ادخال تاريخ الأجازه")]
        [DisplayName("تاريخ الأجازه")]
        public DateTime? dateHoliday { get; set; }
    }
}
