using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class changeevent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingDate",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Event",
                newName: "EventStartDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Event",
                newName: "EventEndDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EventClosingDate",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventClosingDate",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "EventStartDate",
                table: "Event",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EventEndDate",
                table: "Event",
                newName: "EndDate");

            migrationBuilder.AddColumn<string>(
                name: "ClosingDate",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Event",
                nullable: true);
        }
    }
}
