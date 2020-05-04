using Microsoft.EntityFrameworkCore.Migrations;

namespace CTIN.DataAccess.Migrations
{
    public partial class themcolumnstar_userleanning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "star",
                table: "userLeanning",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "star",
                table: "userLeanning");
        }
    }
}
