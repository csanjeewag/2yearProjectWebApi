using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class addEventtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClosingDate = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EventDescription = table.Column<string>(nullable: true),
                    EventTitle = table.Column<string>(nullable: true),
                    PKey = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OneDayTripRegistrants",
                columns: table => new
                {
                    PKey = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true),
                    NumberOfFamilyMembers = table.Column<string>(nullable: true),
                    TransportationMode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneDayTripRegistrants", x => x.PKey);
                });

            migrationBuilder.CreateTable(
                name: "TwoDayTripRegistrant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accomadation = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true),
                    MealTypeNonVegi = table.Column<string>(nullable: true),
                    MealTypeVegi = table.Column<string>(nullable: true),
                    NumberOfFamilyMembers = table.Column<string>(nullable: true),
                    PKey = table.Column<string>(nullable: true),
                    TransportationMode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwoDayTripRegistrant", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "OneDayTripRegistrants");

            migrationBuilder.DropTable(
                name: "TwoDayTripRegistrant");
        }
    }
}
