using Microsoft.EntityFrameworkCore;
using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class HrDBContext : DbContext
    {
        public HrDBContext(DbContextOptions<HrDBContext> option):base(option)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HR> hRs { get; set; }
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<EmpPhones> EmpPhones { get; set; }
        public virtual DbSet<EmpReport> EmpReports { get; set; }
        public virtual DbSet<EmpTime> EmpTimes { get; set; }
        public virtual DbSet<GeneralSettings> generalsSettings { get; set; }
        public virtual DbSet<Nationality> nationalities { get; set; }
        public virtual DbSet<VacationType> vacationTypes { get; set; }
        public virtual DbSet<TypesOfVacationsEmp> TypesOfVacationsEmps { get; set; }
        public virtual DbSet<Validations> validations { get; set; }


    }
}
