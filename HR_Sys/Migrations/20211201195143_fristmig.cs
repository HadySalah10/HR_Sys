using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Sys.Migrations
{
    public partial class fristmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "validations",
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
                    table.PrimaryKey("PK_validations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hRs",
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
                    table.PrimaryKey("PK_hRs", x => x.hrId);
                    table.ForeignKey(
                        name: "FK_hRs_validations_validationId",
                        column: x => x.validationId,
                        principalTable: "validations",
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
                        name: "FK_Days_hRs_addBy",
                        column: x => x.addBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Days_hRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Days_hRs_editBy",
                        column: x => x.editBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "departments",
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
                    table.PrimaryKey("PK_departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_departments_hRs_addBy",
                        column: x => x.addBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_departments_hRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_departments_hRs_editBy",
                        column: x => x.editBy,
                        principalTable: "hRs",
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
                        name: "FK_Months_hRs_addBy",
                        column: x => x.addBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Months_hRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Months_hRs_editBy",
                        column: x => x.editBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "nationalities",
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
                    table.PrimaryKey("PK_nationalities", x => x.id);
                    table.ForeignKey(
                        name: "FK_nationalities_hRs_addBy",
                        column: x => x.addBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_nationalities_hRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_nationalities_hRs_editBy",
                        column: x => x.editBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "vacationTypes",
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
                    table.PrimaryKey("PK_vacationTypes", x => x.id);
                    table.ForeignKey(
                        name: "FK_vacationTypes_hRs_addBy",
                        column: x => x.addBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_vacationTypes_hRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_vacationTypes_hRs_editBy",
                        column: x => x.editBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
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
                    empGender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    empSsn = table.Column<int>(type: "int", nullable: false),
                    empNetSalary = table.Column<int>(type: "int", nullable: false),
                    empNonNetSalary = table.Column<float>(type: "real", nullable: true),
                    empGrossSalary = table.Column<float>(type: "real", nullable: true),
                    empHireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    requiredAttendanceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    requiredDepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    requiredSalaryPerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    requiredDaysPerMonth = table.Column<int>(type: "int", nullable: true),
                    requiredExtraHours = table.Column<float>(type: "real", nullable: false),
                    requiredDeductHours = table.Column<float>(type: "real", nullable: false),
                    deptid = table.Column<int>(type: "int", nullable: false),
                    nationalityId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Employees_departments_deptid",
                        column: x => x.deptid,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_hRs_addBy",
                        column: x => x.addBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Employees_hRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Employees_hRs_editBy",
                        column: x => x.editBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_Employees_nationalities_nationalityId",
                        column: x => x.nationalityId,
                        principalTable: "nationalities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpPhones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empId = table.Column<int>(type: "int", nullable: false),
                    editBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    addBy = table.Column<int>(type: "int", nullable: true),
                    lastEdit = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPhones", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmpPhones_Employees_empId",
                        column: x => x.empId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpPhones_hRs_addBy",
                        column: x => x.addBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_EmpPhones_hRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_EmpPhones_hRs_editBy",
                        column: x => x.editBy,
                        principalTable: "hRs",
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
                        name: "FK_EmpReports_hRs_addBy",
                        column: x => x.addBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_EmpReports_hRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_EmpReports_hRs_editBy",
                        column: x => x.editBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_EmpReports_Months_idmonth",
                        column: x => x.idmonth,
                        principalTable: "Months",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generalsSettings",
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
                    table.PrimaryKey("PK_generalsSettings", x => x.id);
                    table.ForeignKey(
                        name: "FK_generalsSettings_Employees_empId",
                        column: x => x.empId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generalsSettings_hRs_addBy",
                        column: x => x.addBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_generalsSettings_hRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_generalsSettings_hRs_editBy",
                        column: x => x.editBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                });

            migrationBuilder.CreateTable(
                name: "TypesOfVacationsEmps",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<int>(type: "int", nullable: false),
                    vacId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        name: "FK_TypesOfVacationsEmps_hRs_addBy",
                        column: x => x.addBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_TypesOfVacationsEmps_hRs_deletedBy",
                        column: x => x.deletedBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_TypesOfVacationsEmps_hRs_editBy",
                        column: x => x.editBy,
                        principalTable: "hRs",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK_TypesOfVacationsEmps_vacationTypes_vacId",
                        column: x => x.vacId,
                        principalTable: "vacationTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_departments_addBy",
                table: "departments",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_departments_deletedBy",
                table: "departments",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_departments_editBy",
                table: "departments",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_addBy",
                table: "Employees",
                column: "addBy");

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
                name: "IX_EmpPhones_addBy",
                table: "EmpPhones",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPhones_deletedBy",
                table: "EmpPhones",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPhones_editBy",
                table: "EmpPhones",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPhones_empId",
                table: "EmpPhones",
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
                name: "IX_generalsSettings_addBy",
                table: "generalsSettings",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_generalsSettings_deletedBy",
                table: "generalsSettings",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_generalsSettings_editBy",
                table: "generalsSettings",
                column: "editBy");

            migrationBuilder.CreateIndex(
                name: "IX_generalsSettings_empId",
                table: "generalsSettings",
                column: "empId");

            migrationBuilder.CreateIndex(
                name: "IX_hRs_validationId",
                table: "hRs",
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
                name: "IX_nationalities_addBy",
                table: "nationalities",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_nationalities_deletedBy",
                table: "nationalities",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_nationalities_editBy",
                table: "nationalities",
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
                name: "IX_vacationTypes_addBy",
                table: "vacationTypes",
                column: "addBy");

            migrationBuilder.CreateIndex(
                name: "IX_vacationTypes_deletedBy",
                table: "vacationTypes",
                column: "deletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_vacationTypes_editBy",
                table: "vacationTypes",
                column: "editBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpPhones");

            migrationBuilder.DropTable(
                name: "EmpReports");

            migrationBuilder.DropTable(
                name: "generalsSettings");

            migrationBuilder.DropTable(
                name: "TypesOfVacationsEmps");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "vacationTypes");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "nationalities");

            migrationBuilder.DropTable(
                name: "hRs");

            migrationBuilder.DropTable(
                name: "validations");
        }
    }
}
