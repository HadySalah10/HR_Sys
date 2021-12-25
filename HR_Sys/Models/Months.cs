using HR_Sys.Models.BaseIDEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models
{
    public class Months:CommonProps
    {

        public string nameMonth { get; set; }
        public string nameMonthEnglish { get; set; }

        public virtual ICollection<EmpReport> EmpReports{ get; set; }
    }
}