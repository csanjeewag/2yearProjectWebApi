using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class forienkeytoproject2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "PrId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Employees",
                newName: "ProjectPrId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ProjectId",
                table: "Employees",
                newName: "IX_Employees_ProjectPrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectPrId",
                table: "Employees",
                column: "ProjectPrId",
                principalTable: "Projects",
                principalColumn: "PrId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectPrId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PrId",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProjectPrId",
                table: "Employees",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ProjectPrId",
                table: "Employees",
                newName: "IX_Employees_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
