using Microsoft.EntityFrameworkCore.Migrations;

namespace CTIN.DataAccess.Migrations
{
    public partial class addminstageRank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "listFilmLearned",
                table: "userLeanning",
                newName: "listfilmlearned");

            migrationBuilder.AddColumn<int>(
                name: "pointminStage",
                table: "rank",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pointminStage",
                table: "rank");

            migrationBuilder.RenameColumn(
                name: "listfilmlearned",
                table: "userLeanning",
                newName: "listFilmLearned");
        }
    }
}
