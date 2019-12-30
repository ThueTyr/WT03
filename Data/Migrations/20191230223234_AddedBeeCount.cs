using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WT03.Data.Migrations
{
    public partial class AddedBeeCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeeCounts",
                columns: table => new
                {
                    BeeCountModelId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeeHiveName = table.Column<string>(maxLength: 18, nullable: false),
                    CountTime = table.Column<DateTime>(nullable: false),
                    NumberOfMidgets = table.Column<int>(nullable: false),
                    ObservationDays = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeeCounts", x => x.BeeCountModelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeeCounts");
        }
    }
}
