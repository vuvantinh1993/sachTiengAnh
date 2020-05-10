using Microsoft.EntityFrameworkCore.Migrations;

namespace CTIN.DataAccess.Migrations
{
    public partial class deleterankInUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rankId",
                table: "userLeanning");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rankId",
                table: "userLeanning",
                nullable: false,
                defaultValue: 0);
        }
    }
}
