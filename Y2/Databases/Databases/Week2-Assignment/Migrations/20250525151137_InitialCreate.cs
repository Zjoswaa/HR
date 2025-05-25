using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Week2_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Number = table.Column<string>(type: "char(6)", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false),
                    ManagerSSN = table.Column<string>(type: "char(9)", nullable: false),
                    ManagerStartDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLocation",
                columns: table => new
                {
                    DepartmentNumber = table.Column<string>(type: "char(6)", nullable: false),
                    Location = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLocation", x => new { x.DepartmentNumber, x.Location });
                    table.ForeignKey(
                        name: "FK_DepartmentLocation_Department_DepartmentNumber",
                        column: x => x.DepartmentNumber,
                        principalTable: "Department",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "char(9)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    MiddleInitials = table.Column<string>(type: "varchar(5)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Salary = table.Column<double>(type: "double precision", nullable: false),
                    DepartmentNumber = table.Column<string>(type: "char(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentNumber",
                        column: x => x.DepartmentNumber,
                        principalTable: "Department",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Number = table.Column<string>(type: "char(6)", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    DepartmentNumber = table.Column<string>(type: "char(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Project_Department_DepartmentNumber",
                        column: x => x.DepartmentNumber,
                        principalTable: "Department",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependent",
                columns: table => new
                {
                    EmployeeSSN = table.Column<string>(type: "char(9)", nullable: false),
                    DependentName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependent", x => new { x.EmployeeSSN, x.DependentName });
                    table.ForeignKey(
                        name: "FK_Dependent_Employee_EmployeeSSN",
                        column: x => x.EmployeeSSN,
                        principalTable: "Employee",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorksOn",
                columns: table => new
                {
                    EmployeeSSN = table.Column<string>(type: "char(9)", nullable: false),
                    ProjectNumber = table.Column<string>(type: "char(6)", nullable: false),
                    Hours = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksOn", x => new { x.EmployeeSSN, x.ProjectNumber });
                    table.ForeignKey(
                        name: "FK_WorksOn_Employee_EmployeeSSN",
                        column: x => x.EmployeeSSN,
                        principalTable: "Employee",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksOn_Project_ProjectNumber",
                        column: x => x.ProjectNumber,
                        principalTable: "Project",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_ManagerSSN",
                table: "Department",
                column: "ManagerSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentNumber",
                table: "Employee",
                column: "DepartmentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Project_DepartmentNumber",
                table: "Project",
                column: "DepartmentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOn_ProjectNumber",
                table: "WorksOn",
                column: "ProjectNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_ManagerSSN",
                table: "Department",
                column: "ManagerSSN",
                principalTable: "Employee",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_ManagerSSN",
                table: "Department");

            migrationBuilder.DropTable(
                name: "DepartmentLocation");

            migrationBuilder.DropTable(
                name: "Dependent");

            migrationBuilder.DropTable(
                name: "WorksOn");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
