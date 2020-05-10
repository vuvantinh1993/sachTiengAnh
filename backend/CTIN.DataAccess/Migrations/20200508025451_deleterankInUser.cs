using Microsoft.EntityFrameworkCore.Migrations;

namespace CTIN.DataAccess.Migrations
{
    public partial class deleterankInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userLeanning_rank_rankId",
                table: "userLeanning");

            migrationBuilder.DropIndex(
                name: "IX_userLeanning_rankId",
                table: "userLeanning");

            migrationBuilder.DropColumn(
                name: "star",
                table: "userLeanning");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "star",
                table: "userLeanning",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_userLeanning_rankId",
                table: "userLeanning",
                column: "rankId");

            migrationBuilder.AddForeignKey(
                name: "FK_userLeanning_rank_rankId",
                table: "userLeanning",
                column: "rankId",
                principalTable: "rank",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
