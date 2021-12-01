using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class GeneralSettings: CommonProps
    {
        public DateTime? attendanceTime { get; set; }
        public DateTime? departureTime { get; set; }
        public float? extraHours { get; set; }
        public float? deductHours { get; set; }
        public decimal? extraAmount { get; set; }
        public decimal? deductAmount { get; set; }
        public bool? isOff { get; set; }

        //relation with employee
        [ForeignKey("Employee")]
        public int empId { get; set; }
        public virtual Employee Employee { get; set; }


    }
}
