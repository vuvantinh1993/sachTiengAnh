using Microsoft.EntityFrameworkCore.Migrations;

namespace CTIN.DataAccess.Migrations
{
    public partial class them_feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "feedBackaboutWord",
                table: "WordFilm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "listPeopleContribute",
                table: "WordFilm",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "feedBackaboutWord",
                table: "WordFilm");

            migrationBuilder.DropColumn(
                name: "listPeopleContribute",
                table: "WordFilm");
        }
    }
}
