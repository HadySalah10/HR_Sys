using Microsoft.EntityFrameworkCore;

namespace HR_Sys.Models
{
    public class HrDBContext : DbContext
    {
        public HrDBContext(DbContextOptions<HrDBContext> option) : base(option)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HR> hRs { get; set; }
        public virtual DbSet<EmpPhones> EmpPhones { get; set; }
        public virtual DbSet<EmpReport> EmpReports { get; set; }
        public virtual DbSet<EmployeeAttendance> EmployeesAttendance { get; set; }
        public virtual DbSet<Nationality> nationalities { get; set; }
        public virtual DbSet<VacationType> vacationTypes { get; set; }
        public virtual DbSet<Department> departments { get; set; }

        public virtual DbSet<TypesOfVacationsEmp> TypesOfVacationsEmps { get; set; }
        public virtual DbSet<Validations> validations { get; set; }
        public virtual DbSet<Months> Months { get; set; }
        public virtual DbSet<Days> Days { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Days>().HasData(
                new Days { id=1, daysName = "Saturday" },
                new Days {id=2, daysName = "Sunday" },
                new Days {id=3, daysName = "Monday" },
                new Days {id=4, daysName = "Tuesday" },
                new Days {id=5, daysName = "Wednesday" },
                new Days {id=6, daysName = "Thursday" },
                new Days {id=7, daysName = "Friday" }
            );
            modelBuilder.Entity<Months>().HasData(
               new Months { id = 1, nameMonth = "January" },
               new Months { id = 2, nameMonth = "February" },
               new Months { id = 3, nameMonth = "March" },
               new Months { id = 4, nameMonth = "April" },
               new Months { id = 5, nameMonth = "May" },
               new Months { id = 6, nameMonth = "June" },
               new Months { id = 7, nameMonth = "July" },
               new Months { id = 8, nameMonth = "August" },
               new Months { id = 9, nameMonth = "September" },
               new Months { id = 10, nameMonth = "October" },
               new Months { id = 11, nameMonth = "November" },
               new Months { id = 12, nameMonth = "December" }
           );
            modelBuilder.Entity<Nationality>().HasData(
           new Nationality { id = 1, nationalityName = "Egypt" },
           new Nationality { id = 2, nationalityName = "England" },
           new Nationality { id = 3, nationalityName = "France" },
           new Nationality { id = 4, nationalityName = "Germany" },
           new Nationality { id = 5, nationalityName = "Oman" },
           new Nationality { id = 6, nationalityName = "Morocco" },
           new Nationality { id = 7, nationalityName = "Saudi Arabia" },
           new Nationality { id = 8, nationalityName = "Sudan" },
           new Nationality { id = 9, nationalityName = "September" },
           new Nationality { id = 10, nationalityName = "The United Arab Emirates" },
           new Nationality { id = 11, nationalityName = "Libya" },
           new Nationality { id = 12, nationalityName = "Jordan" }
       );

        }
    }
}
