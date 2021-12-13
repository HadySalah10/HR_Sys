using HR_Sys.Models.BaseIDEntity;
using System.ComponentModel;

namespace HR_Sys.Models
{
    public class NameAnnualHoliday:CommonProps
    {
        [DisplayName("اسـم الأجازه")]
        public string? nameHoliday { get; set; }
        public virtual ICollection<annualHoliday>? AnnualHolidays { get; set; }
    }
}
