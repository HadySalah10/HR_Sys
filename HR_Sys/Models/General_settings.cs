using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models
{
    public class General_settings:commonprops
    {
        public DateTime? attendance_time { get; set; }
        public DateTime? departure_time { get; set; }
        public float? extra_hours { get; set; }
        public float? deduct_hours { get; set; }
        public decimal? extra_amount { get; set; }
        public decimal? deduct_amount { get; set; }
        public bool? is_off { get; set; }

        //relation with employee
        [ForeignKey("Employee")]
        public int emp_id { get; set; }
        public virtual Employee Employee { get; set; }


    }
}
