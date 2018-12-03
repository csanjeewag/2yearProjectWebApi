using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class forienkeytoproject3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectPrId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectPrId",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectPrId",
                table: "Employees",
                column: "ProjectPrId",
                principalTable: "Projects",
                principalColumn: "PrId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectPrId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectPrId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectPrId",
                table: "Employees",
                column: "ProjectPrId",
                principalTable: "Projects",
                principalColumn: "PrId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
