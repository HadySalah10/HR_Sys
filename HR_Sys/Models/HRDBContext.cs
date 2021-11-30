using Microsoft.EntityFrameworkCore;

namespace HR_Sys.Models
{
    public class HRDBContext:DbContext
    {
        public HRDBContext(DbContextOptions<HRDBContext>option):base(option)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HR> hRs { get; set; }
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<Emp_Phones> Emp_Phones { get; set; }
        public virtual DbSet<Emp_Report> Emp_Reports { get; set; }
        public virtual DbSet<Emp_Time> Emp_Times { get; set; }
        public virtual DbSet<General_settings> general_Settings { get; set; }
        public virtual DbSet<Nationality> nationalities { get; set; }
        public virtual DbSet<Vacation_Type> vacation_Types { get; set; }
        public virtual DbSet<Types_Of_Vacations_emp> types_Of_Vacations_Emps { get; set; }
        public virtual DbSet<Validations> validations { get; set; }


    }
}
