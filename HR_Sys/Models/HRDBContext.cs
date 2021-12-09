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
            // dummy Data for testing 
            modelBuilder.Entity<HR>().HasData(
           new HR { hrId = 1, fullName = "admin admin", hrUserName = "admin20", password = "admin@1234", email = "hady20@admin.com", validationId = 1 }

       );
            modelBuilder.Entity<Employee>().HasData(
        new Employee {id=1, empName="test User", empAddress="كوكب الارض", empDateOfBirth = new DateTime(2008, 1, 1) }

    );
            modelBuilder.Entity<Validations>().HasData(
       new Validations
       {
           validationName = "Admin",
           empAdd = true,
           empEdit = true,
           empDisplay = true,
           empDelete = true,
           gsAdd = true,
           gsEdit = true,
           gsDisplay = true,
           gsDelete = true,
           attendAdd = true,
           attendEdit = true,
           attendDelete = true,
           attendDisplay = true,
           reportAdd = true,
           reportEdit = true,
           reportDelete = true,
           reportDisplay = true,
           id = 1
       }

   );
            modelBuilder.Entity<Days>().HasData(
                new Days { id=1, daysName = "Saturday" ,addBy=1,lastEdit=true },
                new Days {id=2, daysName = "Sunday", addBy = 1, lastEdit = true },
                new Days {id=3, daysName = "Monday", addBy = 1, lastEdit = true },
                new Days {id=4, daysName = "Tuesday", addBy = 1, lastEdit = true },
                new Days {id=5, daysName = "Wednesday", addBy = 1, lastEdit = true },
                new Days {id=6, daysName = "Thursday", addBy = 1, lastEdit = true },
                new Days {id=7, daysName = "Friday", addBy = 1, lastEdit = true }
            );
         
          
            modelBuilder.Entity<Months>().HasData(
               new Months { id = 1, nameMonth = "January", addBy = 1, lastEdit = true },
               new Months { id = 2, nameMonth = "February", addBy = 1, lastEdit = true },
               new Months { id = 3, nameMonth = "March", addBy = 1, lastEdit = true },
               new Months { id = 4, nameMonth = "April", addBy = 1, lastEdit = true },
               new Months { id = 5, nameMonth = "May", addBy = 1, lastEdit = true },
               new Months { id = 6, nameMonth = "June", addBy = 1, lastEdit = true },
               new Months { id = 7, nameMonth = "July", addBy = 1, lastEdit = true },
               new Months { id = 8, nameMonth = "August", addBy = 1, lastEdit = true },
               new Months { id = 9, nameMonth = "September", addBy = 1, lastEdit = true },
               new Months { id = 10, nameMonth = "October", addBy = 1, lastEdit = true },
               new Months { id = 11, nameMonth = "November", addBy = 1, lastEdit = true },
               new Months { id = 12, nameMonth = "December", addBy = 1, lastEdit = true }
           );
            modelBuilder.Entity<Nationality>().HasData(
           new Nationality { id = 1, nationalityName = "Egypt", addBy = 1, lastEdit = true },
           new Nationality { id = 2, nationalityName = "England", addBy = 1, lastEdit = true },
           new Nationality { id = 3, nationalityName = "France", addBy = 1, lastEdit = true },
           new Nationality { id = 4, nationalityName = "Germany", addBy = 1, lastEdit = true },
           new Nationality { id = 5, nationalityName = "Oman", addBy = 1, lastEdit = true },
           new Nationality { id = 6, nationalityName = "Morocco", addBy = 1, lastEdit = true },
           new Nationality { id = 7, nationalityName = "Saudi Arabia", addBy = 1, lastEdit = true },
           new Nationality { id = 8, nationalityName = "Sudan", addBy = 1, lastEdit = true },
           new Nationality { id = 9, nationalityName = "September", addBy = 1, lastEdit = true },
           new Nationality { id = 10, nationalityName = "The United Arab Emirates", addBy = 1, lastEdit = true },
           new Nationality { id = 11, nationalityName = "Libya", addBy = 1, lastEdit = true },
           new Nationality { id = 12, nationalityName = "Jordan", addBy = 1, lastEdit = true }
       );
           

        }
    }
}
