namespace HR_Sys.Models
{
    public class Emp_Time :commonprops
    {

        public DateTime? required_attendance_time { get; set; } 
        public DateTime? required_departure_time { get; set; }
        public decimal? required_salaryPerHour { get; set; }
        public int? required_daysPerMonth { get; set; }
        public string name_of_theday { get; set; }

        //relation with employee
        public virtual List<Employee> employees { get; set; }

    }
}
