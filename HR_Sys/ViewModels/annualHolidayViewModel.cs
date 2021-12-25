using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models;
using HR_Sys.Models.BaseIDEntity;



namespace HR_Sys.ViewModels
{
    public class annualHolidayViewModel
    {
        //اسم الأجازه 
        [DisplayName("اسـم الأجازه")]
        //[Required(ErrorMessage = "برجاء تحديد اسـم الأجازه")]
        public string displayNameEnglish { get; set; }

        //تاريخ الأجازه
        [Required(ErrorMessage = "برجاء ادخال تاريخ الأجازه")]
        [DisplayName("تاريخ الأجازه")]
        public DateTime? dateHoliday { get; set; }
    }
}
