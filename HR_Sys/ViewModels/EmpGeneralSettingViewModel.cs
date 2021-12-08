using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;
using HR_Sys.ValidationsAttributes;

namespace HR_Sys.ViewModels
{
    public class EmpGeneralSettingViewModel
    {

        [Required(ErrorMessage = "*")]
        public DateTime? requiredAttendanceTime { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime? requiredDepartureTime { get; set; }
        public decimal? requiredSalaryPerHour { get; set; }
        public int? requiredDaysPerMonth { get; set; }

        [Required(ErrorMessage = "*")]
        public float requiredExtraHours { get; set; }
        [Required(ErrorMessage = "*")]
        public float requiredDeductHours { get; set; }
    }
}
