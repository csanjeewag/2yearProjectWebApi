using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class addTaskModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_Id",
                table: "EmployeeTasks");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "TaskInformations",
                newName: "File");

            migrationBuilder.RenameColumn(
                name: "FileID",
                table: "TaskInformations",
                newName: "InfoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmployeeTasks",
                newName: "EId");

            migrationBuilder.AddColumn<float>(
                name: "ActualCost",
                table: "Tasks",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TaskInformations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Employees_EId",
                table: "EmployeeTasks",
                column: "EId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_EId",
                table: "EmployeeTasks");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropColumn(
                name: "ActualCost",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TaskInformations");

            migrationBuilder.RenameColumn(
                name: "File",
                table: "TaskInformations",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "InfoID",
                table: "TaskInformations",
                newName: "FileID");

            migrationBuilder.RenameColumn(
                name: "EId",
                table: "EmployeeTasks",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Employees_Id",
                table: "EmployeeTasks",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
