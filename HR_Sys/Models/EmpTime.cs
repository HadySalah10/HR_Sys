using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;



namespace HR_Sys.Models
{
    public class EmpTime : CommonProps
    {
        [Required(ErrorMessage ="Required")]
        public DateTime? requiredAttendanceTime { get; set; }

        [Required(ErrorMessage = "Required")]
        public DateTime? requiredDepartureTime { get; set; }
        public decimal? requiredSalaryPerHour { get; set; }
        public int? requiredDaysPerMonth { get; set; }
        public string nameOfDay { get; set; }

        //relation with employee
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
