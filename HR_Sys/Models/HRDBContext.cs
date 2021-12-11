using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HR_Sys.Models
{
    public class HrDBContext : DbContext
    {
        public HrDBContext(DbContextOptions<HrDBContext> option) : base(option)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HR> HRs { get; set; }
        public virtual DbSet<EmpReport> EmpReports { get; set; }
        public virtual DbSet<EmployeeAttendance> EmployeesAttendance { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<VacationType> VacationTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<TypesOfVacationsEmp> TypesOfVacationsEmps { get; set; }
        public virtual DbSet<Validations> Validations { get; set; }
        public virtual DbSet<Months> Months { get; set; }
        public virtual DbSet<Days> Days { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // dummy Data for testing 
            modelBuilder.Entity<HR>().HasData(
           new HR { hrId = 1, fullName = "admin admin", hrUserName = "admin20", password = "admin@1234", email = "hady20@admin.com", validationId = 1 }

       );
            modelBuilder.Entity<Department>().HasData(
              new Department { id = 1, deptName = "قسم العلاقات العامة", addBy = 1, lastEdit = true },
              new Department { id = 2, deptName = " قسم الموارد البشرية", addBy = 1, lastEdit = true },
              new Department { id = 3, deptName = "قسم التطوير", addBy = 1, lastEdit = true },
              new Department { id = 4, deptName = "قسم التسويق", addBy = 1, lastEdit = true },
              new Department { id = 5, deptName = "قسم المبيعات", addBy = 1, lastEdit = true }
         
          );
            modelBuilder.Entity<NameAnnualHoliday>().HasData(
             new NameAnnualHoliday { id = 1, nameHoliday = "عيد الغطاس",  addBy = 1, lastEdit = true },
             new NameAnnualHoliday { id = 2, nameHoliday = "عيد الاضحي", addBy = 1, lastEdit = true },
             new NameAnnualHoliday { id = 3, nameHoliday = "عيد الفطر", addBy = 1, lastEdit = true }
           

         );
            modelBuilder.Entity<annualHoliday>().HasData(
        new annualHoliday { id = 1, idHoliday = 1,dateHoliday= new DateTime(2021, 1, 19), addBy = 1, lastEdit = true }
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
                new Days { id=1, daysName = "السبت" ,addBy=1,lastEdit=true },
                new Days {id=2, daysName = "الاحد", addBy = 1, lastEdit = true },
                new Days {id=3, daysName = "الاثنين", addBy = 1, lastEdit = true },
                new Days {id=4, daysName = "الثلاثاء", addBy = 1, lastEdit = true },
                new Days {id=5, daysName = "الاربعاء", addBy = 1, lastEdit = true },
                new Days {id=6, daysName = "الخميس", addBy = 1, lastEdit = true },
                new Days {id=7, daysName = "الجمعة", addBy = 1, lastEdit = true }
            );
         
          
            modelBuilder.Entity<Months>().HasData(
               new Months { id = 1, nameMonth = "يناير", addBy = 1, lastEdit = true },
               new Months { id = 2, nameMonth = "فبارير", addBy = 1, lastEdit = true },
               new Months { id = 3, nameMonth = "مارس", addBy = 1, lastEdit = true },
               new Months { id = 4, nameMonth = "ابريل", addBy = 1, lastEdit = true },
               new Months { id = 5, nameMonth = "مايو", addBy = 1, lastEdit = true },
               new Months { id = 6, nameMonth = "يونيو", addBy = 1, lastEdit = true },
               new Months { id = 7, nameMonth = "يوليو", addBy = 1, lastEdit = true },
               new Months { id = 8, nameMonth = "اغسطس", addBy = 1, lastEdit = true },
               new Months { id = 9, nameMonth = "سبتمبر", addBy = 1, lastEdit = true },
               new Months { id = 10, nameMonth = "اكتوبر", addBy = 1, lastEdit = true },
               new Months { id = 11, nameMonth = "نوفمبر", addBy = 1, lastEdit = true },
               new Months { id = 12, nameMonth = "ديسمبر", addBy = 1, lastEdit = true }
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
            modelBuilder.Entity<Employee>().HasData(
   new Employee
   {
       id = 1,
       empName = "test User",
       empAddress = "كوكب الارض",
       empDateOfBirth = new DateTime(1997, 5, 21),
       empGender = true,
       empSsn = "29705251400191",
       empNetSalary = 600.20,
       empNonNetSalary = 100.20,
       empGrossSalary = 600.20 + 100.20,
       empHireDate = new DateTime(2008, 1, 1),
       requiredAttendanceTime = new DateTime(2008, 1, 1, 9, 0, 0),
       requiredDepartureTime = new DateTime(2008, 1, 1, 16, 0, 0),
       requiredSalaryPerHour = 50,
       requiredDaysPerMonth = 5,
       requiredExtraHours = 2,
       requiredDeductHours = 2,
       addBy = 1,
       deptid = 1,
       nationalityId = 1,
       phoneNum = "01119959346",
       phoneNum2 = "01554904905",
       annualHolidayId = 1
       
   }

);
           
            modelBuilder.Entity<VacationType>().HasData(
            new VacationType { id = 1, vacationName = "اجازة اسبوعية", addBy = 1, lastEdit = true },
            new VacationType { id = 2, vacationName = "اجازة عارضة", addBy = 1, lastEdit = true },
            new VacationType { id = 3, vacationName = "اجازة سنوية", addBy = 1, lastEdit = true }

        );
            modelBuilder.Entity<TypesOfVacationsEmp>().HasData(
          new TypesOfVacationsEmp { id = 1, empId=1 , vacId=1,idDays=1,date=null, addBy = 1, lastEdit = true },
          new TypesOfVacationsEmp { id = 2, empId=1 , vacId=1,idDays=7, date = null, addBy = 1, lastEdit = true }
         

      );


        }
    }
}
