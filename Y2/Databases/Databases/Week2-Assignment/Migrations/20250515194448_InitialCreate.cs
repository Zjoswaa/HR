using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                name: "Departments",
                columns: table => new
                {
                    Dnumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dname = table.Column<string>(type: "text", nullable: false),
                    Mgr_ssn = table.Column<int>(type: "integer", nullable: false),
                    Mgr_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Dnumber);
                });

            migrationBuilder.CreateTable(
                name: "DeptLocations",
                columns: table => new
                {
                    Dno = table.Column<int>(type: "integer", nullable: false),
                    Dlocation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptLocations", x => new { x.Dno, x.Dlocation });
                    table.ForeignKey(
                        name: "FK_DeptLocations_Departments_Dno",
                        column: x => x.Dno,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Ssn = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fname = table.Column<string>(type: "text", nullable: false),
                    Minit = table.Column<char>(type: "character(1)", nullable: false),
                    Lname = table.Column<string>(type: "text", nullable: false),
                    Bdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<char>(type: "character(1)", nullable: false),
                    Salary = table.Column<int>(type: "integer", nullable: false),
                    Super_ssn = table.Column<int>(type: "integer", nullable: false),
                    Dno = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Ssn);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_Dno",
                        column: x => x.Dno,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_Super_ssn",
                        column: x => x.Super_ssn,
                        principalTable: "Employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Pno = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pname = table.Column<string>(type: "text", nullable: false),
                    Plocation = table.Column<string>(type: "text", nullable: false),
                    Dno = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Pno);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_Dno",
                        column: x => x.Dno,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Essn = table.Column<int>(type: "integer", nullable: false),
                    Dependent_name = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<char>(type: "character(1)", nullable: false),
                    Bdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => new { x.Essn, x.Dependent_name });
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_Essn",
                        column: x => x.Essn,
                        principalTable: "Employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorksOn",
                columns: table => new
                {
                    Essn = table.Column<int>(type: "integer", nullable: false),
                    Pno = table.Column<int>(type: "integer", nullable: false),
                    Hours = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksOn", x => new { x.Essn, x.Pno });
                    table.ForeignKey(
                        name: "FK_WorksOn_Employees_Essn",
                        column: x => x.Essn,
                        principalTable: "Employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksOn_Projects_Pno",
                        column: x => x.Pno,
                        principalTable: "Projects",
                        principalColumn: "Pno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Mgr_ssn",
                table: "Departments",
                column: "Mgr_ssn");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Dno",
                table: "Employees",
                column: "Dno");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Super_ssn",
                table: "Employees",
                column: "Super_ssn");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Dno",
                table: "Projects",
                column: "Dno");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOn_Pno",
                table: "WorksOn",
                column: "Pno");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_Mgr_ssn",
                table: "Departments",
                column: "Mgr_ssn",
                principalTable: "Employees",
                principalColumn: "Ssn",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_Mgr_ssn",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "DeptLocations");

            migrationBuilder.DropTable(
                name: "WorksOn");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
