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
        
        public int anoholidayId { get; set; }

        //اسم الأجازه 
        [DisplayName("اسـم الأجازه")]
        //[Required(ErrorMessage = "برجاء تحديد اسـم الأجازه")]

        [ForeignKey("NameAnnualHoliday")]
        public int  idHoliday { get; set; }
        public virtual NameAnnualHoliday? NameAnnualHoliday { get; set; }

        //تاريخ الأجازه
        [Required(ErrorMessage = "برجاء ادخال تاريخ الأجازه")]
        [DisplayName("تاريخ الأجازه")]
        public DateTime? dateHoliday { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
