using HR_Sys.Models.BaseIDEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models
{
    public class annualHoliday: CommonProps
    {
        [Required]
        [ForeignKey("NameAnnualHoliday")]
        public int  idHoliday { get; set; }
        public virtual NameAnnualHoliday NameAnnualHoliday { get; set; }
        public DateTime dateHoliday { get; set; }

    }
}
