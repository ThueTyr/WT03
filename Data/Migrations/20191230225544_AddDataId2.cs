using Microsoft.EntityFrameworkCore.Migrations;

namespace WT03.Data.Migrations
{
    public partial class AddDataId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "BeeCounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeeCounts_AuthorId",
                table: "BeeCounts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeeCounts_AspNetUsers_AuthorId",
                table: "BeeCounts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeeCounts_AspNetUsers_AuthorId",
                table: "BeeCounts");

            migrationBuilder.DropIndex(
                name: "IX_BeeCounts_AuthorId",
                table: "BeeCounts");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "BeeCounts");
        }
    }
}
