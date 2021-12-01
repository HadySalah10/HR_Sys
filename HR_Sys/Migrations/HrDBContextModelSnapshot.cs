﻿// <auto-generated />
using System;
using HR_Sys.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HR_Sys.Migrations
{
    [DbContext(typeof(HrDBContext))]
    partial class HrDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HR_Sys.Models.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("addBy")
                        .HasColumnType("int");

                    b.Property<int?>("deletedBy")
                        .HasColumnType("int");

                    b.Property<string>("deptName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("editBy")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("lastEdit")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("addBy");

                    b.HasIndex("deletedBy");

                    b.HasIndex("editBy");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("HR_Sys.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("addBy")
                        .HasColumnType("int");

                    b.Property<int?>("deletedBy")
                        .HasColumnType("int");

                    b.Property<int>("deptid")
                        .HasColumnType("int");

                    b.Property<int?>("editBy")
                        .HasColumnType("int");

                    b.Property<string>("empAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("empDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("empGender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("empHireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("empName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("empSsn")
                        .HasColumnType("int");

                    b.Property<int>("empTimeId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("lastEdit")
                        .HasColumnType("bit");

                    b.Property<int>("nationalityId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("addBy");

                    b.HasIndex("deletedBy");

                    b.HasIndex("deptid");

                    b.HasIndex("editBy");

                    b.HasIndex("empTimeId");

                    b.HasIndex("nationalityId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HR_Sys.Models.EmpPhones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("addBy")
                        .HasColumnType("int");

                    b.Property<int?>("deletedBy")
                        .HasColumnType("int");

                    b.Property<int?>("editBy")
                        .HasColumnType("int");

                    b.Property<int>("empId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("lastEdit")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("addBy");

                    b.HasIndex("deletedBy");

                    b.HasIndex("editBy");

                    b.HasIndex("empId");

                    b.ToTable("EmpPhones");
                });

            modelBuilder.Entity("HR_Sys.Models.EmpReport", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("addBy")
                        .HasColumnType("int");

                    b.Property<int?>("deletedBy")
                        .HasColumnType("int");

                    b.Property<int?>("editBy")
                        .HasColumnType("int");

                    b.Property<int>("empId")
                        .HasColumnType("int");

                    b.Property<int>("idmonth")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("lastEdit")
                        .HasColumnType("bit");

                    b.Property<float?>("netSalary")
                        .HasColumnType("real");

                    b.Property<int?>("numAbsenceDays")
                        .HasColumnType("int");

                    b.Property<int?>("numAttendanceDays")
                        .HasColumnType("int");

                    b.Property<float?>("numOfDeductHours")
                        .HasColumnType("real");

                    b.Property<float?>("numOfExtraHours")
                        .HasColumnType("real");

                    b.Property<float?>("totalOfDeductionPrice")
                        .HasColumnType("real");

                    b.Property<float?>("totalOfExtraPrice")
                        .HasColumnType("real");

                    b.Property<int?>("year")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("addBy");

                    b.HasIndex("deletedBy");

                    b.HasIndex("editBy");

                    b.HasIndex("empId");

                    b.HasIndex("idmonth");

                    b.ToTable("EmpReports");
                });

            modelBuilder.Entity("HR_Sys.Models.EmpTime", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("addBy")
                        .HasColumnType("int");

                    b.Property<int?>("deletedBy")
                        .HasColumnType("int");

                    b.Property<int?>("editBy")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("lastEdit")
                        .HasColumnType("bit");

                    b.Property<string>("nameOfDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("requiredAttendanceTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("requiredDaysPerMonth")
                        .HasColumnType("int");

                    b.Property<DateTime?>("requiredDepartureTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("requiredSalaryPerHour")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("addBy");

                    b.HasIndex("deletedBy");

                    b.HasIndex("editBy");

                    b.ToTable("EmpTimes");
                });

            modelBuilder.Entity("HR_Sys.Models.GeneralSettings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("addBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("attendanceTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("deductAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float?>("deductHours")
                        .HasColumnType("real");

                    b.Property<int?>("deletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("departureTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("editBy")
                        .HasColumnType("int");

                    b.Property<int>("empId")
                        .HasColumnType("int");

                    b.Property<decimal?>("extraAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float?>("extraHours")
                        .HasColumnType("real");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("isOff")
                        .HasColumnType("bit");

                    b.Property<bool?>("lastEdit")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("addBy");

                    b.HasIndex("deletedBy");

                    b.HasIndex("editBy");

                    b.HasIndex("empId");

                    b.ToTable("generalsSettings");
                });

            modelBuilder.Entity("HR_Sys.Models.HR", b =>
                {
                    b.Property<int?>("hrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("hrId"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("hrUserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("validationId")
                        .HasColumnType("int");

                    b.HasKey("hrId");

                    b.HasIndex("validationId");

                    b.ToTable("hRs");
                });

            modelBuilder.Entity("HR_Sys.Models.Months", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("addBy")
                        .HasColumnType("int");

                    b.Property<int?>("deletedBy")
                        .HasColumnType("int");

                    b.Property<int?>("editBy")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("lastEdit")
                        .HasColumnType("bit");

                    b.Property<string>("nameMonth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("addBy");

                    b.HasIndex("deletedBy");

                    b.HasIndex("editBy");

                    b.ToTable("Months");
                });

            modelBuilder.Entity("HR_Sys.Models.Nationality", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("addBy")
                        .HasColumnType("int");

                    b.Property<int?>("deletedBy")
                        .HasColumnType("int");

                    b.Property<int?>("editBy")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("lastEdit")
                        .HasColumnType("bit");

                    b.Property<string>("nationalityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("addBy");

                    b.HasIndex("deletedBy");

                    b.HasIndex("editBy");

                    b.ToTable("nationalities");
                });

            modelBuilder.Entity("HR_Sys.Models.TypesOfVacationsEmp", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("VacationTypeid")
                        .HasColumnType("int");

                    b.Property<int?>("addBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deletedBy")
                        .HasColumnType("int");

                    b.Property<int?>("editBy")
                        .HasColumnType("int");

                    b.Property<int>("empId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("lastEdit")
                        .HasColumnType("bit");

                    b.Property<int>("vacId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("VacationTypeid");

                    b.HasIndex("addBy");

                    b.HasIndex("deletedBy");

                    b.HasIndex("editBy");

                    b.HasIndex("empId");

                    b.ToTable("TypesOfVacationsEmps");
                });

            modelBuilder.Entity("HR_Sys.Models.VacationType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("addBy")
                        .HasColumnType("int");

                    b.Property<int?>("deletedBy")
                        .HasColumnType("int");

                    b.Property<int?>("editBy")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("lastEdit")
                        .HasColumnType("bit");

                    b.Property<string>("vacationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("addBy");

                    b.HasIndex("deletedBy");

                    b.HasIndex("editBy");

                    b.ToTable("vacationTypes");
                });

            modelBuilder.Entity("HR_Sys.Models.Validations", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("attendAdd")
                        .HasColumnType("bit");

                    b.Property<bool>("attendDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("attendDisplay")
                        .HasColumnType("bit");

                    b.Property<bool>("attendEdit")
                        .HasColumnType("bit");

                    b.Property<bool>("empAdd")
                        .HasColumnType("bit");

                    b.Property<bool>("empDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("empDisplay")
                        .HasColumnType("bit");

                    b.Property<bool>("empEdit")
                        .HasColumnType("bit");

                    b.Property<bool>("gsAdd")
                        .HasColumnType("bit");

                    b.Property<bool>("gsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("gsDisplay")
                        .HasColumnType("bit");

                    b.Property<bool>("gsEdit")
                        .HasColumnType("bit");

                    b.Property<bool>("reportAdd")
                        .HasColumnType("bit");

                    b.Property<bool>("reportDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("reportDisplay")
                        .HasColumnType("bit");

                    b.Property<bool>("reportEdit")
                        .HasColumnType("bit");

                    b.Property<string>("validationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("validations");
                });

            modelBuilder.Entity("HR_Sys.Models.Department", b =>
                {
                    b.HasOne("HR_Sys.Models.HR", "Add")
                        .WithMany("DepartmentsAdd")
                        .HasForeignKey("addBy");

                    b.HasOne("HR_Sys.Models.HR", "Delete")
                        .WithMany("DepartmentsDelete")
                        .HasForeignKey("deletedBy");

                    b.HasOne("HR_Sys.Models.HR", "edit")
                        .WithMany("DepartmentsEdit")
                        .HasForeignKey("editBy");

                    b.Navigation("Add");

                    b.Navigation("Delete");

                    b.Navigation("edit");
                });

            modelBuilder.Entity("HR_Sys.Models.Employee", b =>
                {
                    b.HasOne("HR_Sys.Models.HR", "Add")
                        .WithMany("EmployeesAdd")
                        .HasForeignKey("addBy");

                    b.HasOne("HR_Sys.Models.HR", "Delete")
                        .WithMany("EmployeesDelete")
                        .HasForeignKey("deletedBy");

                    b.HasOne("HR_Sys.Models.Department", "Department")
                        .WithMany("employees")
                        .HasForeignKey("deptid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HR_Sys.Models.HR", "edit")
                        .WithMany("EmployeesEdit")
                        .HasForeignKey("editBy");

                    b.HasOne("HR_Sys.Models.EmpTime", "EmpTime")
                        .WithMany("Employees")
                        .HasForeignKey("empTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HR_Sys.Models.Nationality", "Nationality")
                        .WithMany("Employees")
                        .HasForeignKey("nationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Add");

                    b.Navigation("Delete");

                    b.Navigation("Department");

                    b.Navigation("EmpTime");

                    b.Navigation("Nationality");

                    b.Navigation("edit");
                });

            modelBuilder.Entity("HR_Sys.Models.EmpPhones", b =>
                {
                    b.HasOne("HR_Sys.Models.HR", "Add")
                        .WithMany()
                        .HasForeignKey("addBy");

                    b.HasOne("HR_Sys.Models.HR", "Delete")
                        .WithMany()
                        .HasForeignKey("deletedBy");

                    b.HasOne("HR_Sys.Models.HR", "edit")
                        .WithMany()
                        .HasForeignKey("editBy");

                    b.HasOne("HR_Sys.Models.Employee", "Employees")
                        .WithMany("EmpPhones")
                        .HasForeignKey("empId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Add");

                    b.Navigation("Delete");

                    b.Navigation("Employees");

                    b.Navigation("edit");
                });

            modelBuilder.Entity("HR_Sys.Models.EmpReport", b =>
                {
                    b.HasOne("HR_Sys.Models.HR", "Add")
                        .WithMany("Emp_ReportsAdd")
                        .HasForeignKey("addBy");

                    b.HasOne("HR_Sys.Models.HR", "Delete")
                        .WithMany("Emp_ReportsDelete")
                        .HasForeignKey("deletedBy");

                    b.HasOne("HR_Sys.Models.HR", "edit")
                        .WithMany("Emp_ReportsEdit")
                        .HasForeignKey("editBy");

                    b.HasOne("HR_Sys.Models.Employee", "Employees")
                        .WithMany("EmpReports")
                        .HasForeignKey("empId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HR_Sys.Models.Months", "Months")
                        .WithMany("EmpReports")
                        .HasForeignKey("idmonth")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Add");

                    b.Navigation("Delete");

                    b.Navigation("Employees");

                    b.Navigation("Months");

                    b.Navigation("edit");
                });

            modelBuilder.Entity("HR_Sys.Models.EmpTime", b =>
                {
                    b.HasOne("HR_Sys.Models.HR", "Add")
                        .WithMany()
                        .HasForeignKey("addBy");

                    b.HasOne("HR_Sys.Models.HR", "Delete")
                        .WithMany()
                        .HasForeignKey("deletedBy");

                    b.HasOne("HR_Sys.Models.HR", "edit")
                        .WithMany()
                        .HasForeignKey("editBy");

                    b.Navigation("Add");

                    b.Navigation("Delete");

                    b.Navigation("edit");
                });

            modelBuilder.Entity("HR_Sys.Models.GeneralSettings", b =>
                {
                    b.HasOne("HR_Sys.Models.HR", "Add")
                        .WithMany("General_Settings")
                        .HasForeignKey("addBy");

                    b.HasOne("HR_Sys.Models.HR", "Delete")
                        .WithMany("General_SettingsDelete")
                        .HasForeignKey("deletedBy");

                    b.HasOne("HR_Sys.Models.HR", "edit")
                        .WithMany("General_SettingsEdit")
                        .HasForeignKey("editBy");

                    b.HasOne("HR_Sys.Models.Employee", "Employee")
                        .WithMany("GeneralSettings")
                        .HasForeignKey("empId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Add");

                    b.Navigation("Delete");

                    b.Navigation("Employee");

                    b.Navigation("edit");
                });

            modelBuilder.Entity("HR_Sys.Models.HR", b =>
                {
                    b.HasOne("HR_Sys.Models.Validations", "Valids")
                        .WithMany("HRs")
                        .HasForeignKey("validationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Valids");
                });

            modelBuilder.Entity("HR_Sys.Models.Months", b =>
                {
                    b.HasOne("HR_Sys.Models.HR", "Add")
                        .WithMany("Months")
                        .HasForeignKey("addBy");

                    b.HasOne("HR_Sys.Models.HR", "Delete")
                        .WithMany("MonthsDelete")
                        .HasForeignKey("deletedBy");

                    b.HasOne("HR_Sys.Models.HR", "edit")
                        .WithMany("MonthsEdit")
                        .HasForeignKey("editBy");

                    b.Navigation("Add");

                    b.Navigation("Delete");

                    b.Navigation("edit");
                });

            modelBuilder.Entity("HR_Sys.Models.Nationality", b =>
                {
                    b.HasOne("HR_Sys.Models.HR", "Add")
                        .WithMany("NationalitiesAdd")
                        .HasForeignKey("addBy");

                    b.HasOne("HR_Sys.Models.HR", "Delete")
                        .WithMany("NationalitiesDelete")
                        .HasForeignKey("deletedBy");

                    b.HasOne("HR_Sys.Models.HR", "edit")
                        .WithMany("NationalitiesEdit")
                        .HasForeignKey("editBy");

                    b.Navigation("Add");

                    b.Navigation("Delete");

                    b.Navigation("edit");
                });

            modelBuilder.Entity("HR_Sys.Models.TypesOfVacationsEmp", b =>
                {
                    b.HasOne("HR_Sys.Models.VacationType", "VacationType")
                        .WithMany("TypesOfVacationsEmps")
                        .HasForeignKey("VacationTypeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HR_Sys.Models.HR", "Add")
                        .WithMany("TypesOfVacationsEmps")
                        .HasForeignKey("addBy");

                    b.HasOne("HR_Sys.Models.HR", "Delete")
                        .WithMany("TypesOfVacationsEmpsDelete")
                        .HasForeignKey("deletedBy");

                    b.HasOne("HR_Sys.Models.HR", "edit")
                        .WithMany("TypesOfVacationsEmpsEdit")
                        .HasForeignKey("editBy");

                    b.HasOne("HR_Sys.Models.Employee", "emp")
                        .WithMany("TypesOfVacationsEmps")
                        .HasForeignKey("empId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Add");

                    b.Navigation("Delete");

                    b.Navigation("VacationType");

                    b.Navigation("edit");

                    b.Navigation("emp");
                });

            modelBuilder.Entity("HR_Sys.Models.VacationType", b =>
                {
                    b.HasOne("HR_Sys.Models.HR", "Add")
                        .WithMany("VacationTypes")
                        .HasForeignKey("addBy");

                    b.HasOne("HR_Sys.Models.HR", "Delete")
                        .WithMany("VacatioTypesDelete")
                        .HasForeignKey("deletedBy");

                    b.HasOne("HR_Sys.Models.HR", "edit")
                        .WithMany("VacatioTypesEdit")
                        .HasForeignKey("editBy");

                    b.Navigation("Add");

                    b.Navigation("Delete");

                    b.Navigation("edit");
                });

            modelBuilder.Entity("HR_Sys.Models.Department", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("HR_Sys.Models.Employee", b =>
                {
                    b.Navigation("EmpPhones");

                    b.Navigation("EmpReports");

                    b.Navigation("GeneralSettings");

                    b.Navigation("TypesOfVacationsEmps");
                });

            modelBuilder.Entity("HR_Sys.Models.EmpTime", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HR_Sys.Models.HR", b =>
                {
                    b.Navigation("DepartmentsAdd");

                    b.Navigation("DepartmentsDelete");

                    b.Navigation("DepartmentsEdit");

                    b.Navigation("Emp_ReportsAdd");

                    b.Navigation("Emp_ReportsDelete");

                    b.Navigation("Emp_ReportsEdit");

                    b.Navigation("EmployeesAdd");

                    b.Navigation("EmployeesDelete");

                    b.Navigation("EmployeesEdit");

                    b.Navigation("General_Settings");

                    b.Navigation("General_SettingsDelete");

                    b.Navigation("General_SettingsEdit");

                    b.Navigation("Months");

                    b.Navigation("MonthsDelete");

                    b.Navigation("MonthsEdit");

                    b.Navigation("NationalitiesAdd");

                    b.Navigation("NationalitiesDelete");

                    b.Navigation("NationalitiesEdit");

                    b.Navigation("TypesOfVacationsEmps");

                    b.Navigation("TypesOfVacationsEmpsDelete");

                    b.Navigation("TypesOfVacationsEmpsEdit");

                    b.Navigation("VacatioTypesDelete");

                    b.Navigation("VacatioTypesEdit");

                    b.Navigation("VacationTypes");
                });

            modelBuilder.Entity("HR_Sys.Models.Months", b =>
                {
                    b.Navigation("EmpReports");
                });

            modelBuilder.Entity("HR_Sys.Models.Nationality", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HR_Sys.Models.VacationType", b =>
                {
                    b.Navigation("TypesOfVacationsEmps");
                });

            modelBuilder.Entity("HR_Sys.Models.Validations", b =>
                {
                    b.Navigation("HRs");
                });
#pragma warning restore 612, 618
        }
    }
}