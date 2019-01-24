using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class ChangeTaskInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File",
                table: "TaskInformations",
                newName: "InfoDescription");

            migrationBuilder.AddColumn<int>(
                name: "Contact",
                table: "TaskInformations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Employee",
                table: "TaskInformations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "TaskInformations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_TaskInformations_Contact",
                table: "TaskInformations",
                column: "Contact");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInformations_Employee",
                table: "TaskInformations",
                column: "Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInformations_Contacts_Contact",
                table: "TaskInformations",
                column: "Contact",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInformations_Employees_Employee",
                table: "TaskInformations",
                column: "Employee",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskInformations_Contacts_Contact",
                table: "TaskInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInformations_Employees_Employee",
                table: "TaskInformations");

            migrationBuilder.DropIndex(
                name: "IX_TaskInformations_Contact",
                table: "TaskInformations");

            migrationBuilder.DropIndex(
                name: "IX_TaskInformations_Employee",
                table: "TaskInformations");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "TaskInformations");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "TaskInformations");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "TaskInformations");

            migrationBuilder.RenameColumn(
                name: "InfoDescription",
                table: "TaskInformations",
                newName: "File");
        }
    }
}
