using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Sys.Migrations
{
    public partial class HRsystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Validations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    validationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empAdd = table.Column<bool>(type: "bit", nullable: false),
                    empEdit = table.Column<bool>(type: "bit", nullable: false),
                    empDelete = table.Column<bool>(type: "bit", nullable: false),
                    empDisplay = table.Column<bool>(type: "bit", nullable: false),
                    gsAdd = table.Column<bool>(type: "bit", nullable: false),
                    gsEdit = table.Column<bool>(type: "bit", nullable: false),
                    gsDelete = table.Column<bool>(type: "bit", nullable: false),
                    gsDisplay = table.Column<bool>(type: "bit", nullable: false),
                    attendAdd = table.Column<bool>(type: "bit", nullable: false),
                    attendEdit = table.Column<bool>(type: "bit", nullable: false),
                    attendDelete = table.Column<bool>(type: "bit", nullable: false),
                    attendDisplay = table.Column<bool>(type: "bit", nullable: false),
                    reportAdd = table.Column<bool>(type: "bit", nullable: false),
                    reportEdit = table.Column<bool>(type: "bit", nullable: false),
                    reportDelete = table.Column<bool>(type: "bit", nullable: false),
                    reportDisplay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HRs",
                columns: table => new
                {
                    hrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hrUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    validationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRs", x => x.hrId);
                    table.ForeignKey(
                        name: "FK_HRs_Validations_validationId",
                        column: x => x.validationId,
                        principalTable: "Validations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    daysName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.id);
                    table.ForeignKey(
                        name: "FK_Days_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Days_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Days_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deptName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Departments_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Departments_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Departments_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.id);
                    table.ForeignKey(
                        name: "FK_Months_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Months_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Months_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "NameAnnualHoliday",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameHoliday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameAnnualHoliday", x => x.id);
                    table.ForeignKey(
                        name: "FK_NameAnnualHoliday_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_NameAnnualHoliday_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_NameAnnualHoliday_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nationalityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Nationalities_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Nationalities_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Nationalities_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "VacationTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationTypes", x => x.id);
                    table.ForeignKey(
                        name: "FK_VacationTypes_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_VacationTypes_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_VacationTypes_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "annualHoliday",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idHoliday = table.Column<int>(type: "int", nullable: false),
                    dateHoliday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_annualHoliday", x => x.id);
                    table.ForeignKey(
                        name: "FK_annualHoliday_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_annualHoliday_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_annualHoliday_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_annualHoliday_NameAnnualHoliday_idHoliday",
                        column: x => x.idHoliday,
                        principalTable: "NameAnnualHoliday",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    empAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    empDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empGender = table.Column<bool>(type: "bit", nullable: false),
                    empSsn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empNetSalary = table.Column<double>(type: "float", nullable: false),
                    empNonNetSalary = table.Column<double>(type: "float", nullable: true),
                    empGrossSalary = table.Column<double>(type: "float", nullable: true),
                    empHireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    requiredAttendanceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    requiredDepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    requiredSalaryPerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    requiredDaysPerMonth = table.Column<int>(type: "int", nullable: true),
                    requiredExtraHours = table.Column<float>(type: "real", nullable: false),
                    requiredDeductHours = table.Column<float>(type: "real", nullable: false),
                    phoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNum2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deptid = table.Column<int>(type: "int", nullable: false),
                    nationalityId = table.Column<int>(type: "int", nullable: false),
                    annualHolidayId = table.Column<int>(type: "int", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_annualHoliday_annualHolidayId",
                        column: x => x.annualHolidayId,
                        principalTable: "annualHoliday",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_deptid",
                        column: x => x.deptid,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Employees_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Employees_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Employees_Nationalities_nationalityId",
                        column: x => x.nationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesAttendance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attendanceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    departureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    extraHours = table.Column<float>(type: "real", nullable: true),
                    deductHours = table.Column<float>(type: "real", nullable: true),
                    extraAmount = table.Column<float>(type: "real", nullable: true),
                    deductAmount = table.Column<float>(type: "real", nullable: true),
                    isOff = table.Column<bool>(type: "bit", nullable: true),
                    empId = table.Column<int>(type: "int", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesAttendance", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmployeesAttendance_Employees_empId",
                        column: x => x.empId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesAttendance_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_EmployeesAttendance_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_EmployeesAttendance_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "EmpReports",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idmonth = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: true),
                    numAttendanceDays = table.Column<int>(type: "int", nullable: true),
                    numAbsenceDays = table.Column<int>(type: "int", nullable: true),
                    numOfExtraHours = table.Column<float>(type: "real", nullable: true),
                    numOfDeductHours = table.Column<float>(type: "real", nullable: true),
                    totalOfExtraPrice = table.Column<float>(type: "real", nullable: true),
                    totalOfDeductionPrice = table.Column<float>(type: "real", nullable: true),
                    NonNetSalary = table.Column<float>(type: "real", nullable: true),
                    GrossSalary = table.Column<float>(type: "real", nullable: true),
                    netSalary = table.Column<float>(type: "real", nullable: true),
                    empId = table.Column<int>(type: "int", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpReports", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmpReports_Employees_empId",
                        column: x => x.empId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpReports_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_EmpReports_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_EmpReports_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_EmpReports_Months_idmonth",
                        column: x => x.idmonth,
                        principalTable: "Months",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfVacationsEmps",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<int>(type: "int", nullable: false),
                    vacId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    idDays = table.Column<int>(type: "int", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfVacationsEmps", x => x.id);
                    table.ForeignKey(
                        name: "FK_TypesOfVacationsEmps_Days_idDays",
                        column: x => x.idDays,
                        principalTable: "Days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypesOfVacationsEmps_Employees_empId",
                        column: x => x.empId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypesOfVacationsEmps_HRs_addBy",
                        column: x => x.addBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_TypesOfVacationsEmps_HRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_TypesOfVacationsEmps_HRs_editBy",
                        column: x => x.editBy,
                        principalTable: "HRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_TypesOfVacationsEmps_VacationTypes_vacId",
                        column: x => x.vacId,
                        principalTable: "VacationTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Validations",
                columns: new[] { "id", "attendAdd", "attendDelete", "attendDisplay", "attendEdit", "empAdd", "empDelete", "empDisplay", "empEdit", "gsAdd", "gsDelete", "gsDisplay", "gsEdit", "reportAdd", "reportDelete", "reportDisplay", "reportEdit", "validationName" },
                values: new object[] { 1, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, "Admin" });

            migrationBuilder.InsertData(
                table: "HRs",
                columns: new[] { "hrId", "email", "fullName", "hrUserName", "password", "validationId" },
                values: new object[] { 1, "hady20@admin.com", "admin admin", "admin20", "admin@1234", 1 });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "id", "addBy", "daysName", "deletedBy", "editBy", "isDeleted", "lastEdit" },
                values: new object[,]
                {
                    { 1, 1, "السبت", null, null, false, true },
                    { 2, 1, "الاحد", null, null, false, true },
                    { 3, 1, "الاثنين", null, null, false, true },
                    { 4, 1, "الثلاثاء", null, null, false, true },
                    { 5, 1, "الاربعاء", null, null, false, true },
                    { 6, 1, "الخميس", null, null, false, true },
                    { 7, 1, "الجمعة", null, null, false, true }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "id", "addBy", "deletedBy", "deptName", "editBy", "isDeleted", "lastEdit" },
                values: new object[,]
                {
                    { 1, 1, null, "قسم العلاقات العامة", null, false, true },
                    { 2, 1, null, " قسم الموارد البشرية", null, false, true },
                    { 3, 1, null, "قسم التطوير", null, false, true },
                    { 4, 1, null, "قسم التسويق", null, false, true },
                    { 5, 1, null, "قسم المبيعات", null, false, true }
                });

            migrationBuilder.InsertData(
                table: "Months",
                columns: new[] { "id", "addBy", "deletedBy", "editBy", "isDeleted", "lastEdit", "nameMonth" },
                values: new object[,]
                {
                    { 1, 1, null, null, false, true, "يناير" },
                    { 2, 1, null, null, false, true, "فبارير" },
                    { 3, 1, null, null, false, true, "مارس" },
                    { 4, 1, null, null, false, true, "ابريل" },
                    { 5, 1, null, null, false, true, "مايو" },
                    { 6, 1, null, null, false, true, "يونيو" },
                    { 7, 1, null, null, false, true, "يوليو" },
                    { 8, 1, null, null, false, true, "اغسطس" },
                    { 9, 1, null, null, false, true, "سبتمبر" },
                    { 10, 1, null, null, false, true, "اكتوبر" },
                    { 11, 1, null, null, false, true, "نوفمبر" },
                    { 12, 1, null, null, false, true, "ديسمبر" }
                });

            migrationBuilder.InsertData(
                table: "NameAnnualHoliday",
                columns: new[] { "id", "addBy", "deletedBy", "editBy", "isDeleted", "lastEdit", "nameHoliday" },
                values: new object[,]
                {
                    { 1, 1, null, null, false, true, "عيد الغطاس" },
                    { 2, 1, null, null, false, true, "عيد الاضحي" },
                    { 3, 1, null, null, false, true, "عيد الفطر" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "id", "addBy", "deletedBy", "editBy", "isDeleted", "lastEdit", "nationalityName" },
                values: new object[,]
                {
                    { 1, 1, null, null, false, true, "Egypt" },
                    { 2, 1, null, null, false, true, "England" },
                    { 3, 1, null, null, false, true, "France" },
                    { 4, 1, null, null, false, true, "Germany" },
                    { 5, 1, null, null, false, true, "Oman" },
                    { 6, 1, null, null, false, true, "Morocco" },
                    { 7, 1, null, null, false, true, "Saudi Arabia" },
                    { 8, 1, null, null, false, true, "Sudan" },
                    { 9, 1, null, null, false, true, "September" },
                    { 10, 1, null, null, false, true, "The United Arab Emirates" },
                    { 11, 1, null, null, false, true, "Libya" },
                    { 12, 1, null, null, false, true, "Jordan" }
                });

            migrationBuilder.InsertData(
                table: "VacationTypes",
                columns: new[] { "id", "addBy", "deletedBy", "editBy", "isDeleted", "lastEdit", "vacationName" },
                values: new object[,]
                {
                    { 1, 1, null, null, false, true, "اجازة اسبوعية" },
                    { 2, 1, null, null, false, true, "اجازة عارضة" },
                    { 3, 1, null, null, false, true, "اجازة سنوية" }
                });

            migrationBuilder.InsertData(
                table: "annualHoliday",
                columns: new[] { "id", "addBy", "dateHoliday", "deletedBy", "editBy", "idHoliday", "isDeleted", "lastEdit" },
                values: new object[] { 1, 1, new DateTime(2021, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, false, true });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "id", "addBy", "annualHolidayId", "deletedBy", "deptid", "editBy", "empAddress", "empDateOfBirth", "empGender", "empGrossSalary", "empHireDate", "empName", "empNetSalary", "empNonNetSalary", "empSsn", "isDeleted", "lastEdit", "nationalityId", "phoneNum", "phoneNum2", "requiredAttendanceTime", "requiredDaysPerMonth", "requiredDeductHours", "requiredDepartureTime", "requiredExtraHours", "requiredSalaryPerHour" },
                values: new object[] { 1, 1, 1, null, 1, null, "كوكب الارض", new DateTime(1997, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 700.40000000000009, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test User", 600.20000000000005, 100.2, "29705251400191", false, true, 1, "01119959346", "01554904905", new DateTime(2008, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, 2f, new DateTime(2008, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 2f, 50m });

            migrationBuilder.InsertData(
                table: "TypesOfVacationsEmps",
                columns: new[] { "id", "addBy", "date", "deletedBy", "editBy", "empId", "idDays", "isDeleted", "lastEdit", "vacId" },
                values: new object[] { 1, 1, null, null, null, 1, 1, false, true, 1 });

            migrationBuilder.InsertData(
                table: "TypesOfVacationsEmps",
                columns: new[] { "id", "addBy", "date", "deletedBy", "editBy", "empId", "idDays", "isDeleted", "lastEdit", "vacId" },
                values: new object[] { 2, 1, null, null, null, 1, 7, false, true, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_annualHoliday_addBy",
                table: "annualHoliday",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_annualHoliday_deletedBy",
                table: "annualHoliday",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_annualHoliday_editBy",
                table: "annualHoliday",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_annualHoliday_idHoliday",
                table: "annualHoliday",
                column: "idHoliday");

            migrationBuilder.CreateIndex(
                name: "IX_Days_addBy",
                table: "Days",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_Days_deletedBy",
                table: "Days",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Days_editBy",
                table: "Days",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_addBy",
                table: "Departments",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_deletedBy",
                table: "Departments",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_editBy",
                table: "Departments",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_addBy",
                table: "Employees",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_annualHolidayId",
                table: "Employees",
                column: "annualHolidayId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_deletedBy",
                table: "Employees",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_deptid",
                table: "Employees",
                column: "deptid");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_editBy",
                table: "Employees",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_nationalityId",
                table: "Employees",
                column: "nationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesAttendance_addBy",
                table: "EmployeesAttendance",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesAttendance_deletedBy",
                table: "EmployeesAttendance",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesAttendance_editBy",
                table: "EmployeesAttendance",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesAttendance_empId",
                table: "EmployeesAttendance",
                column: "empId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpReports_addBy",
                table: "EmpReports",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpReports_deletedBy",
                table: "EmpReports",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpReports_editBy",
                table: "EmpReports",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpReports_empId",
                table: "EmpReports",
                column: "empId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpReports_idmonth",
                table: "EmpReports",
                column: "idmonth");

            migrationBuilder.CreateIndex(
                name: "IX_HRs_validationId",
                table: "HRs",
                column: "validationId");

            migrationBuilder.CreateIndex(
                name: "IX_Months_addBy",
                table: "Months",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_Months_deletedBy",
                table: "Months",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Months_editBy",
                table: "Months",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_NameAnnualHoliday_addBy",
                table: "NameAnnualHoliday",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_NameAnnualHoliday_deletedBy",
                table: "NameAnnualHoliday",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NameAnnualHoliday_editBy",
                table: "NameAnnualHoliday",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_Nationalities_addBy",
                table: "Nationalities",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_Nationalities_deletedBy",
                table: "Nationalities",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Nationalities_editBy",
                table: "Nationalities",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfVacationsEmps_addBy",
                table: "TypesOfVacationsEmps",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfVacationsEmps_deletedBy",
                table: "TypesOfVacationsEmps",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfVacationsEmps_editBy",
                table: "TypesOfVacationsEmps",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfVacationsEmps_empId",
                table: "TypesOfVacationsEmps",
                column: "empId");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfVacationsEmps_idDays",
                table: "TypesOfVacationsEmps",
                column: "idDays");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfVacationsEmps_vacId",
                table: "TypesOfVacationsEmps",
                column: "vacId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationTypes_addBy",
                table: "VacationTypes",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_VacationTypes_deletedBy",
                table: "VacationTypes",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VacationTypes_editBy",
                table: "VacationTypes",
                column: "editBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesAttendance");

            migrationBuilder.DropTable(
                name: "EmpReports");

            migrationBuilder.DropTable(
                name: "TypesOfVacationsEmps");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "VacationTypes");

            migrationBuilder.DropTable(
                name: "annualHoliday");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "NameAnnualHoliday");

            migrationBuilder.DropTable(
                name: "HRs");

            migrationBuilder.DropTable(
                name: "Validations");
        }
    }
}
