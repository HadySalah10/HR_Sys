using HR_Sys.Models.BaseIDEntity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.ValidationsAttributes;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sys.Models
{
    public class annualHoliday: CommonProps
    {
        
     

        //اسم الأجازه 
        [DisplayName("اسـم الأجازه")]
        //[Required(ErrorMessage = "برجاء تحديد اسـم الأجازه")]

        public string  nameHoliday { get; set; }

        //تاريخ الأجازه
        [Required(ErrorMessage = "برجاء ادخال تاريخ الأجازه")]
        [DisplayName("تاريخ الأجازه")]
        public DateTime? dateHoliday { get; set; }

    }
}
