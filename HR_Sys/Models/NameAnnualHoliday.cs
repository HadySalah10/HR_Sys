using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class NameAnnualHoliday:CommonProps
    {
        public string nameHoliday { get; set; }
        public virtual ICollection<annualHoliday> AnnualHolidays { get; set; }
    }
}
