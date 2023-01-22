using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC2.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    location = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    startDate = table.Column<DateTime>(type: "Date", nullable: true),
                    employeeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    minit = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    lname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    salary = table.Column<int>(type: "int", nullable: true),
                    birthday = table.Column<DateTime>(type: "Date", nullable: true),
                    supervisorid = table.Column<int>(type: "int", nullable: true),
                    departmentWFid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_employees_departments_departmentWFid",
                        column: x => x.departmentWFid,
                        principalTable: "departments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_employees_employees_supervisorid",
                        column: x => x.supervisorid,
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    location = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    departmentid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_departments_departmentid",
                        column: x => x.departmentid,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dependents",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    employeeid = table.Column<int>(type: "int", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    birthday = table.Column<DateTime>(type: "Date", nullable: true),
                    relationship = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    order = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependents", x => new { x.name, x.employeeid });
                    table.ForeignKey(
                        name: "FK_dependents_employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workson",
                columns: table => new
                {
                    employeeid = table.Column<int>(type: "int", nullable: false),
                    projectid = table.Column<int>(type: "int", nullable: false),
                    hours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workson", x => new { x.employeeid, x.projectid });
                    table.ForeignKey(
                        name: "FK_workson_employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workson_projects_projectid",
                        column: x => x.projectid,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments_employeeid",
                table: "departments",
                column: "employeeid",
                unique: true,
                filter: "[employeeid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_dependents_employeeid",
                table: "dependents",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_employees_departmentWFid",
                table: "employees",
                column: "departmentWFid");

            migrationBuilder.CreateIndex(
                name: "IX_employees_supervisorid",
                table: "employees",
                column: "supervisorid");

            migrationBuilder.CreateIndex(
                name: "IX_projects_departmentid",
                table: "projects",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_workson_projectid",
                table: "workson",
                column: "projectid");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_employees_employeeid",
                table: "departments",
                column: "employeeid",
                principalTable: "employees",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_employees_employeeid",
                table: "departments");

            migrationBuilder.DropTable(
                name: "dependents");

            migrationBuilder.DropTable(
                name: "workson");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
