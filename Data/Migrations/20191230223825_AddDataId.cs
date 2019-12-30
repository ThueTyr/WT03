using Microsoft.EntityFrameworkCore.Migrations;

namespace WT03.Data.Migrations
{
    public partial class AddDataId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdOfAuthor",
                table: "BeeCounts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserDataId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOfAuthor",
                table: "BeeCounts");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "AspNetUsers");
        }
    }
}
