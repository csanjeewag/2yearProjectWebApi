using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class addcricketteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CricketTeams",
                columns: table => new
                {
                    CriTeamID = table.Column<string>(nullable: false),
                    CriTeamCaptionContact = table.Column<string>(nullable: true),
                    CriTeamCaptionEmail = table.Column<string>(nullable: true),
                    CriTeamCaptionName = table.Column<string>(nullable: true),
                    CriTeamName = table.Column<string>(nullable: true),
                    CriTeamNonVegitarion = table.Column<string>(nullable: true),
                    CriTeamParticipations = table.Column<string>(nullable: true),
                    CriTeamVegitarion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CricketTeams", x => x.CriTeamID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CricketTeams");
        }
    }
}
