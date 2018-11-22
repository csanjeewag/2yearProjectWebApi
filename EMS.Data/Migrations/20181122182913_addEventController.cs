using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class addEventController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FrontPages",
                columns: table => new
                {
                    CriEventId = table.Column<string>(nullable: false),
                    CriEventContent1 = table.Column<string>(nullable: true),
                    CriEventContent2 = table.Column<string>(nullable: true),
                    CriEventDate = table.Column<DateTime>(nullable: false),
                    CriEventDeadLine = table.Column<DateTime>(nullable: false),
                    CriEventMainTopic = table.Column<string>(nullable: true),
                    CriEventPlace = table.Column<string>(nullable: true),
                    CriEventSubTopic = table.Column<string>(nullable: true),
                    CriEventTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontPages", x => x.CriEventId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FrontPages");
        }
    }
}
